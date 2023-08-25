using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Contracts.Constants;
using Contracts.DbContexts;
using Contracts.DTOs.User;
using Domain.Entities.Address;
using Domain.Entities.Auth;
using Domain.Entities.User;
using FluentResults;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace Shop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    //TODO: Override Problem method with problem factory to use Result<IERROR>
    private readonly IUserDbContext _userContext;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    private readonly ISender _sender;

    public AuthController(IConfiguration configuration, IMapper mapper, IUserDbContext userContext, ISender sender)
    {

        _configuration = configuration;
        _mapper = mapper;
        _userContext = userContext;
        _sender = sender;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserCommand request)
    {
        Result<UserResult> result = await _sender.Send(request);

        if (result.IsSuccess)
            return Ok(result.Value);

        return Problem(result.Errors[0].Message);
    }

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login(UserLoginDTO request)
    {
        // UserToken TokenInfo = JWTToken.GetBearerTokenInfo(Request.Headers[HeaderNames.Authorization]);

        //TODO: Checnge User to just needed field (desctruct from here or dbcontext)
        User? u = await _userContext.GetUser(request.Email, null);

        if (u != null)
        {
            using (var JWTToken = new HashGenerator(request.Password!, new HMACSHA512(u.PasswordSalt), u.Password))
            {

                if (JWTToken.CheckPassword())
                {
                    JWTTokenConfiguration TokenAttributes = new JWTTokenConfiguration(_configuration.GetValue<string>("JWT:Issuer")!,
                        _configuration.GetValue<string>("JWT:Audience")!, request.Email, u.UserRoleID, u.ID,
                        _configuration.GetValue<string>("JWT:Key")!, 45);


                    JwtSecurityToken TOKEN = JWTToken.CreateJWTToken(TokenAttributes);

                    return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(TOKEN) });
                }

                else return Unauthorized("Invalid username/password");
            }
        }

        return Unauthorized("You do not have any account with this email!");
    }


}