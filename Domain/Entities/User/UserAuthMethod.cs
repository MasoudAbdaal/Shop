using Domain.Entities.Auth;
using static Domain.Entities.Auth.AuthProvider;

namespace Domain.Entities.User;

public class UserAuthMethod
{
    public byte[]? UserID { get; set; }
    public Providers AuthProviderID { get; set; } = Providers.EMAIL;
    public AuthProvider? AuthProvider { get; set; }
    public User? User { get; set; }
}
