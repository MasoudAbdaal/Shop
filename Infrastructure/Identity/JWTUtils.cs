using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.Entities.Auth;
using Domain.Entities.User;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity;


public static class JWTUtils
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

    public static bool CheckPassword(string password, byte[] salt, byte[] hash)
    {
        HMACSHA512 HashAlgorithm = new HMACSHA512(salt);

        return HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password)).SequenceEqual(hash);
    }

}