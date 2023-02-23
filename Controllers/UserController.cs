using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetTopologySuite.Geometries;
using Shop.Constants;
using Shop.Data;
using Shop.Data.Interface;
using Shop.DTOs;
using Shop.Models;
using static Shop.Models.Role;

namespace Shop.Controllers
{

  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserRepo _repository;
    private readonly IConfiguration _configuration;

    public UserController(IUserRepo repository, IConfiguration configuration)
    {
      _repository = repository;
      _configuration = configuration;
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

      User u = new User
      {
        ID = new Guid(RandomNumberGenerator.GetBytes(16)).ToByteArray(),
        Name = request.Name,
        Email = request.Email,
        Password = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(request.Password!)),
        PasswordSalt = HashAlgorithm.Key,
        UserInfo = new UserInfo
        {
          PhoneNumber = request.PhoneNumber
        },
      };

      await _repository.CreateUser(u);

      return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDTO request)
    {
      User? u = await _repository.GetUser(request.Email, null);

      if (u != null)
      {
        HMACSHA512 HashAlgorithm = new HMACSHA512(u.PasswordSalt);

        if (HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(request.Password!)).SequenceEqual(u.Password))
        {
          SymmetricSecurityKey signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
          SigningCredentials signingCredential = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha512Signature);

          List<Claim> Claims = new List<Claim>
        {
        new Claim(JwtRegisteredClaimNames.Iss,_configuration.GetValue<string>("JWT:Issuer")),
        new Claim(JwtRegisteredClaimNames.Aud,_configuration.GetValue<string>("JWT:Audience")),
        new Claim(JwtRegisteredClaimNames.Exp, String.Format("{0}",Convert.ToInt32((DateTime.Now.AddDays(5) - new DateTime(1970, 1, 1)).TotalSeconds))),
        new Claim(JwtRegisteredClaimNames.Email, (request.Email)),
        };
          JwtHeader HEADERS = new JwtHeader(signingCredential);
          JwtPayload PAYLOAD = new JwtPayload(Claims);
          JwtSecurityToken TOKEN = new JwtSecurityToken(HEADERS, PAYLOAD);

          return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(TOKEN) });
        }

        else return Unauthorized();
      }

      return NotFound();
    }

  }



}