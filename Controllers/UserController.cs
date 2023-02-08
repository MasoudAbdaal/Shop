using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.DTOs;
using Shop.Models;
using static Shop.Models.Role;

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

        ID = new Guid(RandomNumberGenerator.GetBytes(16)).ToByteArray(),
        Name = "NewNameHello",
        Email = "asdjalskdjl@asdkalsdkja",
        Password = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes("123321")),
        PasswordSalt = HashAlgorithm.Key,
        UserInfo = new UserInfo { },

        UserVerificationMethods = new Collection<UserVerificationMethod> {
           new UserVerificationMethod { VerificationMethodID = VerificationMethod.VerifyMethods.EMAIL },
           new UserVerificationMethod { VerificationMethodID = VerificationMethod.VerifyMethods.TOKEN },
      },
        UserAuthMethods = new Collection<UserAuthMethod> {
         new UserAuthMethod {AuthProviderID = AuthProvider.Providers.EMAIL },
         new UserAuthMethod {AuthProviderID = AuthProvider.Providers.GOOGLE },
         new UserAuthMethod {AuthProviderID = AuthProvider.Providers.MICROSOFT }, },
        Role = UserRoles.SELLER,

      };

      _context.Users.Add(u);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }


}