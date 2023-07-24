using Domain.Entities.User;

namespace Domain.Entities.Auth;

public class AuthProvider
{
    public enum Providers : byte
    {
        EMAIL, GOOGLE, FACEBOOK, MICROSOFT
    }

    public Providers ID { get; set; }

    public string? Name { get; set; }

    public ICollection<UserAuthMethod>? UserAuthMethods { get; set; }
}
