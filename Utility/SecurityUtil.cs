using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using Shop.Models;

namespace Shop.Utility
{

  public static class SecurityUtil
  {
    public static UserToken GetTokenInfo(string userToken)
    {
      JwtSecurityToken Token = new JwtSecurityTokenHandler().ReadJwtToken(userToken);

      string mail = Token.Payload.First(z => z.Key == "email").Value.ToString()!;
      string id = Token.Payload.First(z => z.Key == "nameid").Value.ToString()!;
      string role = Token.Payload.First(z => z.Key == "role").Value.ToString()!;



      return new UserToken(id, mail, Enum.Parse<Role.UserRoles>(role, true));
    }

  }
}