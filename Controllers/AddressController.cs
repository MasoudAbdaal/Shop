using AutoMapper;
using Contracts.DTOs.Address;
using Domain.Entities.Address;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IRepositoryManager _repoManager;


  public AddressController(IRepositoryManager repoManager, IMapper mapper)
  {
    _mapper = mapper;
    _repoManager = repoManager;
  }

  [HttpPost, Route("new")]
  public async Task<ActionResult<Address?>> New(AddressCreateDTO request)
  {
    byte[]? uid = _repoManager.Address.GetUserID(request.Mail);
    uint? RegionID = _repoManager.Address.CheckRegionExist(request.RegionName);

    if (uid is null)
      return NotFound("User doesn't exist");

    if (RegionID is null)
      return NotFound("Region doesn't exist!");

    Random r = new Random();
    byte[] AddressID = new byte[4];
    r.NextBytes(AddressID);

    Address Address = _mapper.Map<AddressCreateDTO, Address>(request);
    Address.ID = AddressID;
    Address.RegionID = (uint)RegionID;

    Address? Result = await _repoManager.Address.AddAddress(Address, uid);

    if (Result is not null)
      return Ok(_mapper.Map<Address, AddressPresentationDTO>(Result));

    return StatusCode(504);

  }

  [HttpPost, Route("modify")]
  public async Task<ActionResult<AddressPresentationDTO>> Modify(AddressPresentationDTO request)
  {
    Address? Address = await _repoManager.Address.GetAddressByID(request.AddressID);
    if (Address is null)
      return NotFound("Wrong addressID");

    var z = _mapper.Map<AddressPresentationDTO, Address>(request);


    await _repoManager.Address.ModifyAddress(z, Address);

    return Ok();
  }

  [HttpGet, Route("all")]
  public async Task<ActionResult<IEnumerable<AddressPresentationDTO>>> GetAll(string email)
  {
    byte[]? uid = _repoManager.Address.GetUserID(email);
    if (uid is null)
      return NotFound();

    IEnumerable<Address>? addressList = await _repoManager.Address.GetUserAddresses(uid!);

    return Ok(_mapper.Map<IEnumerable<Address>, IEnumerable<AddressPresentationDTO>>(addressList!));

  }

  [HttpGet, Route("regions")]
  public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
  {
    return Ok(await _repoManager.Address.GetRegions());
  }

  [HttpPost, Route("delete")]
  public async Task<ActionResult> Delete(AddressDeleteDTO request)
  {
    Address? Address = await _repoManager.Address.GetAddressByID(request.AddressID);
    if (Address is null)
      return NotFound("Invalid AddressID!!");

    if (await _repoManager.Address.DeleteAddress(request.AddressID, request.UserID))
      return Ok();

    return StatusCode(StatusCodes.Status502BadGateway);
  }
}