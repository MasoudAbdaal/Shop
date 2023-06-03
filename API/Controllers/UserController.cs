using AutoMapper;
using Contracts.DbContexts;
using Contracts.DTOs.User;
using Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserDbContext _userContext;

    public UserController(IRepositoryManager repoManager, IMapper mapper, IUserDbContext userContext)
    {
        _mapper = mapper;
        _userContext = userContext;
    }



    [HttpPost("modify")]
    public async Task<IActionResult> Modify(UserModifyDTO request)
    {
        User? Result = await _userContext.GetUser(request.Mail, null);

        if (Result != null)
        {
            await _userContext.EditUserInfo(Result, request);

            return Ok();
        }
        else return NotFound();
    }
}