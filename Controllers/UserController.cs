using System.Collections.ObjectModel;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Shop.Constants;
using Shop.Data;
using Shop.Data.Interface;
using Shop.DTOs;
using Shop.Models;
using static Shop.Models.Role;

namespace Shop.Controllers
{

  [Route("[controller]")]
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
      HMACSHA512 HashAlgorithm = new HMACSHA512(Convert.FromBase64String(_configuration.GetValue<string>("JWT:Key")));

      // await _context.Regions.AddAsync(Countries.IRAN);
      // await _context.Regions.AddAsync(Countries.USA);
      // await _context.SaveChangesAsync();


      // Region? UserRegion = await _context.Regions.FirstAsync(z => z.Name == "IRAN");
      User editedUser = new User() { Email = "asdjalskdjl@asdkalsdkja", Name = "MASOUD" };

      await _repository.EditUser(editedUser);





      User u = new User
      {

        ID = new Guid(RandomNumberGenerator.GetBytes(16)).ToByteArray(),
        Name = "NewNameHello",
        Email = "asdjalskdjl@asdkalsdkja",
        Password = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes("123321")),
        PasswordSalt = HashAlgorithm.Key,

        // UserAddress = new Collection<UserAddress>
        // {
        //   new UserAddress{Address= new Address{
        // Region=UserRegion,
        //   AddressLine="Karaj, Golshahr",PostalCode="asdaklsda",UnitNumber=911,Location =new Point(41.40338, 2.17403){SRID=4326} }}
        // },

        UserInfo = new UserInfo
        {
          CreateDate = DateTime.UtcNow,
          PhoneNumber_Verified = false,
          BirthDate = DateTime.Now.AddDays(365)
        },

        UserVerificationMethods = new Collection<UserVerificationMethod> {
           new UserVerificationMethod { VerificationMethodID = VerificationMethod.VerifyMethods.EMAIL
  },
           new UserVerificationMethod { VerificationMethodID = VerificationMethod.VerifyMethods.TOKEN
},
            },
        UserAuthMethods = new Collection<UserAuthMethod> {
         new UserAuthMethod {AuthProviderID = AuthProvider.Providers.EMAIL },
         new UserAuthMethod {AuthProviderID = AuthProvider.Providers.GOOGLE },
         new UserAuthMethod {AuthProviderID = AuthProvider.Providers.MICROSOFT }, },

        Role = UserRoles.SELLER,


      };

      // await _repository.CreateUser(u);
      // await _context.Users.AddAsync(u);
      // await _context.SaveChangesAsync();
      
      return Ok();
    }
  }



}