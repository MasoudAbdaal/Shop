using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.Entities.Auth;
using Domain.Entities.User;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity;

public partial class HashGenerator : IDisposable
{
    private static Random r = new Random();

    private static HMAC? Algorighm { get; set; }

    private string? ClearPassword { get; set; }

    private byte[]? PasswordHash { get; set; }

    public byte[]? HashingSalt { get; init; }

    public HashGenerator(string clearPassword, HMAC hashingAlgorithm, byte[]? passwordHash)
    {
        ClearPassword = clearPassword;
        Algorighm = hashingAlgorithm;
        HashingSalt = hashingAlgorithm.Key;
        PasswordHash = passwordHash;
    }


    public byte[] CreatePassword() => Algorighm!.ComputeHash(Encoding.UTF8.GetBytes(ClearPassword ?? ""));

    public byte[] CreateRandomID(byte[]? Buffer = null)
    {
        Buffer = Buffer ?? new byte[16];
        r.Next();
        r.NextBytes(Buffer);
        return Buffer.CloneByteArray();
    }

    public bool CheckPassword() => Algorighm!.ComputeHash(Encoding.UTF8.GetBytes(ClearPassword!)).SequenceEqual(PasswordHash!);


    public JwtSecurityToken CreateJWTToken(JWTTokenConfiguration TokenAttributes)
    {

        SymmetricSecurityKey signinKey = new SymmetricSecurityKey(TokenAttributes.TokenKey);
        
        //TODO: Use Algorithm Instead of SecurityAlgorithms.HmacSha512Signature!!
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

    public UserToken GetJWTBearerTokenInfo(StringValues authHeader)
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}