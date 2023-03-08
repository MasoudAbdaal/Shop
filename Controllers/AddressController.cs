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