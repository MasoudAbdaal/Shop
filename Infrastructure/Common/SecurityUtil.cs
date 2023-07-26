using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using Domain.Entities.Auth;
using Domain.Entities.User;
using Microsoft.Extensions.Primitives;

namespace Shop.Utility
{

    public static class SecurityUtil
  {
    public static UserToken GetBearerTokenInfo(StringValues authHeader)
    {
      if (authHeader.Any(z => z!.Contains("Bearer")))
      {

        JwtSecurityToken Token = new JwtSecurityTokenHandler().ReadJwtToken(
          authHeader![authHeader.ToString().IndexOf("Bearer")]!.Split()[1]
          );

        string mail = Token.Payload.First(z => z.Key == "email").Value.ToString()!;
        string id = Token.Payload.First(z => z.Key == "nameid").Value.ToString()!;
        string role = Token.Payload.First(z => z.Key == "role").Value.ToString()!;



        return new UserToken(id, mail, Enum.Parse<Role.UserRoles>(role, true));
      }
      return new UserToken();

    }

  }
}