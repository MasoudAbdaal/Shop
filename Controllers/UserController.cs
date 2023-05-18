using AutoMapper;
using Contracts.DTOs.User;
using Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

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