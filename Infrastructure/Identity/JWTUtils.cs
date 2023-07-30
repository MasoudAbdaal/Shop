using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.Entities.Auth;
using Domain.Entities.User;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity;


public class JWTUtils : IDisposable
{
    public UserToken GetBearerTokenInfo(StringValues authHeader)
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

    public bool CheckPassword(string password, byte[] salt, byte[] hash)
    {
        HMACSHA512 HashAlgorithm = new HMACSHA512(salt);

        var z = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password)).SequenceEqual(hash);

        return HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password)).SequenceEqual(hash);
    }

    public JwtSecurityToken CreateToken(JWTTokenConfiguration TokenAttributes)
    {

        SymmetricSecurityKey signinKey = new SymmetricSecurityKey(TokenAttributes.TokenKey);
        SigningCredentials signingCredential = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha512Signature);

        List<Claim> Claims = new List<Claim>
    {
    new Claim(JwtRegisteredClaimNames.Iss,TokenAttributes.Issuer),
    new Claim(JwtRegisteredClaimNames.Aud,TokenAttributes.Audience),
    new Claim(JwtRegisteredClaimNames.Exp, TokenAttributes.ExpireMinutes),
    new Claim(JwtRegisteredClaimNames.Email, TokenAttributes.UserEmail),
    new Claim(JwtRegisteredClaimNames.NameId, TokenAttributes.UserID),
    new Claim("role",TokenAttributes.UserRole)

    };

        JwtHeader HEADERS = new JwtHeader(signingCredential);
        JwtPayload PAYLOAD = new JwtPayload(Claims);
        return new JwtSecurityToken(HEADERS, PAYLOAD);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}