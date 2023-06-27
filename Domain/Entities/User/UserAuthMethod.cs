using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using static Domain.Entities.Auth.AuthProvider;

namespace Domain.Entities.User;


public class UserAuthMethod
{
    // [ForeignKey(nameof(User)), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[]? UserID { get; set; }

    public User? Users { get; set; }

    [ForeignKey(nameof(AuthProvider)), Column("auth_provider_id"),]
    public Providers? AuthProviderID { get; set; }

    public AuthProvider? AuthProvider { get; set; }

}
