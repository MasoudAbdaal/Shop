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
  public async Task<ActionResult<Address?>> NewAddress(AddressCreateDTO request)
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


  [HttpGet, Route("all")]
  public async Task<ActionResult<IEnumerable<AddressPresentationDTO>>> GetAllAddresses(string email)
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
}