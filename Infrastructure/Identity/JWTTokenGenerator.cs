using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.Entities.User;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity;

public class GenerateToken
{
    private static Random r = new Random(new Random().Next());
    public HMAC Algorighm { get; init; } = new HMACSHA512();
    private byte[] UserID { get; init; } = CreateRandomID(new byte[16]);

    public static byte[] CreateRandomID(byte[]? Buffer = null)
    {
        Buffer = Buffer ?? new byte[16];
        r.Next();
        r.NextBytes(Buffer);
        return Buffer;
    }

      public JwtSecurityToken CreateToken(string userEmail, byte[] userID, Role.UserRoles userRole, double expireMinutes, string issuer, string audience, string key)
    {

        SymmetricSecurityKey signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        SigningCredentials signingCredential = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha512Signature);

        List<Claim> Claims = new List<Claim>
    {
    new Claim(JwtRegisteredClaimNames.Iss,issuer),
    new Claim(JwtRegisteredClaimNames.Aud,audience),
    new Claim(JwtRegisteredClaimNames.Exp, string.Format("{0}",Convert.ToInt32((DateTime.Now.AddMinutes(expireMinutes) - new DateTime(1970, 1, 1)).TotalSeconds))),
    new Claim(JwtRegisteredClaimNames.Email, userEmail),
    new Claim(JwtRegisteredClaimNames.NameId, BitConverter.ToString(userID)),
    new Claim("role",userRole.ToString()),

};

        JwtHeader HEADERS = new JwtHeader(signingCredential);
        JwtPayload PAYLOAD = new JwtPayload(Claims);
        return new JwtSecurityToken(HEADERS, PAYLOAD);
    }

}