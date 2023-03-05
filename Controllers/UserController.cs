using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interface;
using Shop.DTOs;
using Shop.Models;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IUserRepo _repository;

  public UserController(IUserRepo repository, IMapper mapper)
  {
    _mapper = mapper;
    _repository = repository;
  }

  [HttpPost("modify")]
  public async Task<IActionResult> Modify(UserModifyDTO request)
  {
    User? Result = await _repository.GetUser(request.Mail, null);

    if (Result != null)
    {
      await _repository.EditUserInfo(Result, request);

      return Ok();
    }
    else return NotFound();
  }
}