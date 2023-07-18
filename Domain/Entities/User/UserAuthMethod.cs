using Domain.Entities.Auth;
using static Domain.Entities.Auth.AuthProvider;

namespace Domain.Entities.User;

public class UserAuthMethod
{
    public byte[] UserID { get; set; } = new byte[16];
    public byte AuthProviderID { get; set; } = 0;
    public AuthProvider? AuthProvider { get; set; }
    public User? User { get; set; }
}
