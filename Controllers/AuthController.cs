using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Data.Interface;
using Shop.DTOs;
using Shop.Helpers;
using Shop.Models;

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
      byte[] AddressRandID = new byte[4];
      new Random().NextBytes(AddressRandID);

      User u = new User
      {
        ID = new Guid(RandomNumberGenerator.GetBytes(16)).ToByteArray(),
        Name = request.Name,
        Email = request.Email,
        Password = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(request.Password!)),
        PasswordSalt = HashAlgorithm.Key,

        // UserAddress = new Collection<UserAddress> { new UserAddress {
        // AddressID =AddressRandID,

        //  Address = new Address {ID=AddressRandID, AddressLine = "GOLSHAHR OLD",Region=new Region{Name="HOLLAND"} } }
        //  },
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
      User? u = await _repository.GetUser(request.Email, null);

      if (u != null)
      {
        if (Authentication.CheckPassword(request.Password!, u.PasswordSalt))
        {
          JwtSecurityToken TOKEN = Authentication.CreateToken(request.Email, 45,
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

      var HELLO = _mapper.Map<UserAddressDTO, User>(request, z);


      return Ok();
    }
  }


}