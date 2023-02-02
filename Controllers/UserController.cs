using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.DTOs;
using Shop.Models;

namespace Shop.Controllers
{

  [Route("[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserContext _context;
    private readonly IConfiguration _configuration;

    public UserController(UserContext context, IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDTO request)
    {
      HMACSHA512 HashAlgorithm = new HMACSHA512(Convert.FromBase64String(_configuration.GetValue<string>("JWT:Key")));


      User u = new User
      {

        ID = new Guid(Convert.FromBase64String(_configuration.GetValue<string>("Security:GUIDKeyBytes"))).ToByteArray(),
        Name = "",
        Email = "",
        Email_Verified = false,
        Password = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes("123321")),
        PasswordSalt = HashAlgorithm.Key,
        Enabled = true,
        FailedLoginAttempts = 0,
        AuthProvider = Models.User.AuthProviders.NONE,
        Role = Models.User.UserRoles.ADMIN,
        TwoStepMethods = Models.User.TwoStepTypes.NONE,
        PhoneNumber_Verified = false
      };

      _context.Users.Add(u);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }


}