using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interface;
using Shop.DTOs;
using Shop.Models;



[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IAddressRepo _repo;


  public AddressController(IAddressRepo repo, IMapper mapper)
  {
    _mapper = mapper;
    _repo = repo;
  }

  [HttpPost, Route("new")]
  public async Task<ActionResult<Address?>> New(AddressCreateDTO request)
  {
    byte[]? uid = _repo.GetUserID(request.Mail);
    uint? RegionID = _repo.CheckRegionExist(request.RegionName);

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

    Address? Result = await _repo.AddAddress(Address, uid);

    if (Result is not null)
      return Ok(_mapper.Map<Address, AddressPresentationDTO>(Result));

    return StatusCode(504);

  }

  [HttpPost, Route("modify")]
  public async Task<ActionResult<AddressPresentationDTO>> Modify(AddressPresentationDTO request)
  {
    Address? Address = await _repo.GetAddressByID(request.AddressID);
    if (Address is null)
      return NotFound("Wrong addressID");

    var z = _mapper.Map<AddressPresentationDTO, Address>(request);


    await _repo.ModifyAddress(z, Address);

    return Ok();
  }

  [HttpGet, Route("all")]
  public async Task<ActionResult<IEnumerable<AddressPresentationDTO>>> GetAll(string email)
  {
    byte[]? uid = _repo.GetUserID(email);
    if (uid is null)
      return NotFound();

    IEnumerable<Address>? addressList = await _repo.GetUserAddresses(uid!);

    return Ok(_mapper.Map<IEnumerable<Address>, IEnumerable<AddressPresentationDTO>>(addressList!));

  }

  [HttpGet, Route("regions")]
  public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
  {
    return Ok(await _repo.GetRegions());
  }

  [HttpPost, Route("delete")]
  public async Task<ActionResult> Delete(AddressDeleteDTO request)
  {
    Address? Address = await _repo.GetAddressByID(request.AddressID);
    if (Address is null)
      return NotFound("Invalid AddressID!!");

    if (await _repo.DeleteAddress(request.AddressID, request.UserID))
      return Ok();

    return StatusCode(StatusCodes.Status502BadGateway);
  }
}