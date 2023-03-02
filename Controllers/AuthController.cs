using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Shop.Data.Interface;
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
    private readonly IUserRepo _repository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthController(IUserRepo repository, IConfiguration configuration, IMapper mapper)
    {
      _repository = repository;
      _configuration = configuration;
      _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDTO request)
    {

      // await _context.Regions.AddAsync(Countries.IRAN);
      // await _context.Regions.AddAsync(Countries.USA);
      // await _context.SaveChangesAsync();
      // Region? UserRegion = await _context.Regions.FirstAsync(z => z.Name == "IRAN");
      // User editedUser = new User() { Email = "masoud@gmail.com", Name = "newNAME", Role = UserRoles.ADMIN };
      // await _repository.EditUser(editedUser);


      HMACSHA512 HashAlgorithm = new HMACSHA512();
      byte[] AddressID_Random = new byte[4];
      byte[] UserID_Random = new byte[16];
      Random r = new Random();
      r.NextBytes(AddressID_Random);
      r.NextBytes(UserID_Random);

      User u = new User
      {
        ID = UserID_Random,
        Name = request.Name,
        Email = request.Email,
        Password = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(request.Password!)),
        PasswordSalt = HashAlgorithm.Key,

        UserAddress = new Collection<UserAddress> { new UserAddress {
        AddressID =AddressID_Random,

         Address = new Address {ID=AddressID_Random, AddressLine = "GOLSHAHR OLD",Region=new Region{Name="HOLLAND"} } }
         },
        UserInfo = new UserInfo
        {
          PhoneNumber = request.PhoneNumber
        },
      };

      await _repository.CreateUser(u);

      return Ok();
    }

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login(UserLoginDTO request)
    {
      // var z = Request.Headers[HeaderNames.Authorization];

      // var tokenString = z.ToString().Split()[1];

      // var jj = SecurityUtil.GetTokenInfo(tokenString);
      // Console.WriteLine(jj.Role);

      User? u = await _repository.GetUser(request.Email, null);

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

        else return Unauthorized("Invalid password!");
      }

      return NotFound("You do not have any account with this email!");
    }

    [HttpPost, Route("add-mod")]
    public async Task<IActionResult> ModAdd(UserAddressDTO request)
    {
      var z = await _repository.GetUser(request.Email!, null);

      var HELLO = _mapper.Map<UserAddressDTO, User>(request, z!);


      return Ok();
    }
  }


}