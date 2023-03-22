using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Shop.Constants;
using Shop.Data;
using Shop.Data.Repository.Contracts;
using Shop.DTOs;
using Shop.Helpers;
using Shop.Models;
using Shop.Utility;

namespace Shop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IRepositoryManager _repoManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthController(IRepositoryManager repoManager, IConfiguration configuration, IMapper mapper)
    {
      _repoManager = repoManager;
      _configuration = configuration;
      _mapper = mapper;
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
      User? Result = await _repoManager.Auth.CreateUser(u);

      if (Result == null)
        return StatusCode(502);


      return Ok(_mapper.Map<User, UserPresentationDTO>(Result!));

    }

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login(UserLoginDTO request)
    {
      UserToken TokenInfo = SecurityUtil.GetBearerTokenInfo(Request.Headers[HeaderNames.Authorization]);

      User? u = await _repoManager.Auth.GetUser(request.Email, null);

      if (u != null)
      {
        if (Authentication.CheckPassword(request.Password!, u.PasswordSalt, u.Password))
        {
          JwtSecurityToken TOKEN = Authentication.CreateToken(request.Email, u.ID, u.Role, 45,
           _configuration.GetValue<string>("JWT:Issuer"),
           _configuration.GetValue<string>("JWT:Audience"),
           _configuration.GetValue<string>("JWT:Key"));

          return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(TOKEN) });
        }

        else return Unauthorized("Invalid username/password");
      }

      return Unauthorized("You do not have any account with this email!");
    }


  }

}