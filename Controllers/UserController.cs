using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Repository.Contracts;
using Shop.DTOs;
using Shop.Models;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IRepositoryManager _repoManager;

  public UserController(IRepositoryManager repoManager, IMapper mapper)
  {
    _mapper = mapper;
    _repoManager = repoManager;
  }



  [HttpPost("modify")]
  public async Task<IActionResult> Modify(UserModifyDTO request)
  {
    User? Result = await _repoManager.Auth.GetUser(request.Mail, null);

    if (Result != null)
    {
      await _repoManager.User.EditUserInfo(Result, request);

      return Ok();
    }
    else return NotFound();
  }
}