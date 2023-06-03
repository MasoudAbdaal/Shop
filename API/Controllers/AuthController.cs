using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Contracts.Constants;
using Contracts.DbContexts;
using Contracts.DTOs.User;
using Domain.Entities.Address;
using Domain.Entities.Auth;
using Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Shop.Helpers;
using Shop.Utility;

namespace Shop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserDbContext _userContext;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly IUserDbContext _context;

    public AuthController(IConfiguration configuration, IMapper mapper, IUserDbContext context, IUserDbContext userContext)
    {

        _configuration = configuration;
        _mapper = mapper;
        _context = context;
        _userContext = userContext;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDTO request)
    {
        //exmaple code 




        //exmaple code 

        HMACSHA512 HashAlgorithm = new HMACSHA512();
        byte[] AddressID_Random = new byte[4];
        byte[] UserID_Random = new byte[16];
        Random r = new Random();

        r.NextBytes(AddressID_Random);
        r.Next();
        r.NextBytes(UserID_Random);

        var address = new Collection<UserAddress> { new UserAddress {

    AddressID =AddressID_Random.CloneByteArray(),
    UserID = UserID_Random,
     Address = new Address {ID=AddressID_Random.CloneByteArray(), AddressLine = "Address1",Region=Countries.USA,PostalCode= "1",LocationAddress="Location1",UnitNumber=0xcc1 }}
     };

        r.Next();
        r.NextBytes(AddressID_Random);

        address.Add(new UserAddress
        {
            AddressID = AddressID_Random,
            UserID = UserID_Random,
            Address = new Address { ID = AddressID_Random, AddressLine = "Address2", Region = Countries.USA, PostalCode = "2", LocationAddress = "Location2", UnitNumber = 0xcc1 }
        }
                );


        User u = new User
        {
            ID = UserID_Random,
            Name = request.Name,
            Email = request.Email,
            Password = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(request.Password!)),
            PasswordSalt = HashAlgorithm.Key,

            UserAddress = address,
            UserInfo = new UserInfo
            {
                PhoneNumber = request.PhoneNumber
            },
        };
        User? Result = await _userContext.CreateUser(u);

        if (Result == null)
            return StatusCode(502);


        return Ok(_mapper.Map<User, UserPresentationDTO>(Result!));

    }

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login(UserLoginDTO request)
    {
        UserToken TokenInfo = SecurityUtil.GetBearerTokenInfo(Request.Headers[HeaderNames.Authorization]);

        User? u = await _userContext.GetUser(request.Email, null);

        if (u != null)
        {
            if (Authentication.CheckPassword(request.Password!, u.PasswordSalt, u.Password))
            {
                JwtSecurityToken TOKEN = Authentication.CreateToken(request.Email, u.ID, u.Role, 45,
                 _configuration.GetValue<string>("JWT:Issuer")!,
                 _configuration.GetValue<string>("JWT:Audience")!,
                 _configuration.GetValue<string>("JWT:Key")!);

                return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(TOKEN) });
            }

            else return Unauthorized("Invalid username/password");
        }

        return Unauthorized("You do not have any account with this email!");
    }


}