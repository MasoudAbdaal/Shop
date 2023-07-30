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
using Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

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

        HashGenerator HashGenerator = new HashGenerator(request.Password!, new HMACSHA512(), new byte[0]);
        byte[] AddressID_1 = HashGenerator.CreateRandomID(new byte[4]);
        byte[] AddressID_2 = HashGenerator.CreateRandomID(new byte[4]);
        byte[] UserID_Random = HashGenerator.CreateRandomID(new byte[16]);


        var userAddress = new Collection<UserAddress> {new UserAddress
        {
            AddressID =AddressID_1,
            UserID = UserID_Random,
            Address = new Address
            {
                ID=AddressID_1,
                AddressLine = "Address1",
                RegionID=Countries.USA.RegionID,
                PostalCode= "1",
                LocationAddress="Location1",
                UnitNumber=0xcc1
            }
        }
     };
        userAddress.Add(new UserAddress
        {
            AddressID = AddressID_2,
            UserID = UserID_Random,
            Address = new Address
            {
                ID = AddressID_2,
                AddressLine = "Address2",
                RegionID = Countries.USA.RegionID,
                PostalCode = "2",
                LocationAddress = "Location2",
                UnitNumber = 0xcc1
            }
        }
                );


        User u = new User
        {
            ID = UserID_Random,
            Name = request.Name,
            Email = request.Email,
            Password = HashGenerator.CreatePassword(),
            PasswordSalt = HashGenerator.HashingSalt!,
            UserAddresses = userAddress,
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