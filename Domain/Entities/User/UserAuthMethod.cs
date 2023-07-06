using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using static Domain.Entities.Auth.AuthProvider;

namespace Domain.Entities.User;


public class UserAuthMethod
{
    public byte[] UserID { get; set; } = new byte[16];
    public Providers AuthProviderID { get; set; } = Providers.EMAIL;

    public AuthProvider? AuthProvider { get; set; }
    public User? User { get; set; }

}
