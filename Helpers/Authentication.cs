using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Shop.Helpers
{
  public class Authentication
  {
    public static JwtSecurityToken CreateToken(string email, double expireMinutes, string issuer, string audience, string key)
    {

      SymmetricSecurityKey signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
      SigningCredentials signingCredential = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha512Signature);

      List<Claim> Claims = new List<Claim>
        {
        new Claim(JwtRegisteredClaimNames.Iss,issuer),
        new Claim(JwtRegisteredClaimNames.Aud,audience),
        new Claim(JwtRegisteredClaimNames.Exp, String.Format("{0}",Convert.ToInt32((DateTime.Now.AddMinutes(expireMinutes) - new DateTime(1970, 1, 1)).TotalSeconds))),
        new Claim(JwtRegisteredClaimNames.Email, (email)),
        };

      JwtHeader HEADERS = new JwtHeader(signingCredential);
      JwtPayload PAYLOAD = new JwtPayload(Claims);
      return new JwtSecurityToken(HEADERS, PAYLOAD);
    }

    public static bool CheckPassword(string password, byte[] salt)
    {
      HMACSHA512 HashAlgorithm = new HMACSHA512(salt);

      return HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password)).SequenceEqual(salt);
    }
  }
}