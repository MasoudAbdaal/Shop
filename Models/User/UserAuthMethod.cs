using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Shop.Models.AuthProvider;

namespace Shop.Models
{

  public class UserAuthMethod
  {
    [ForeignKey(nameof(User)), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[]? UserID { get; set; }

    public User? Users { get; set; }

    [ForeignKey(nameof(AuthProvider)), Column("auth_provider_id"),]
    public Providers? AuthProviderID { get; set; }

    public AuthProvider? AuthProvider { get; set; }

  }
}
