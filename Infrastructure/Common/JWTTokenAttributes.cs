using System.Text;
using Domain.Entities.User;

public record JWTTokenConfiguration
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string ExpireMinutes { get; init; }
    public string UserEmail { get; init; }
    public string UserRole { get; init; }
    public string UserID { get; init; }
    public byte[] TokenKey { get; init; }

    public JWTTokenConfiguration(string issuer, string audience, string userEmail, Role.UserRoles userRole, byte[] userID, string tokenKey, double expireMinutes = 45)
    {
        Issuer = issuer;
        Audience = audience;
        UserEmail = userEmail;
        UserRole = userRole.ToString();
        ExpireMinutes = string.Format(
            "{0}",
            Convert.ToInt32((DateTime.Now.AddMinutes(expireMinutes) - new DateTime(1970, 1, 1)).TotalSeconds));
        UserID = BitConverter.ToString(userID);
        TokenKey = Encoding.UTF8.GetBytes(tokenKey);
    }
}
