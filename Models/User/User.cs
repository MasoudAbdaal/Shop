using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static Shop.Models.Role;

namespace Shop.Models
{

  [Index(nameof(ID), IsUnique = true)]
  public class User
  {
    [Key, Required, Column("id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(16), DatabaseGenerated(DatabaseGeneratedOption.None)]
    public byte[] ID { get; set; } = new byte[16];

    [Required, Column("name"), MaxLength(40)]
    public string Name { get; set; } = string.Empty;

    [Required, Column("email"), EmailAddress, MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Required, Column("password", TypeName = "Binary"), MaxLength(64)]
    public byte[] Password { get; set; } = new byte[64];

    [Required, Column("password_salt", TypeName = "Binary"), MaxLength(128),]
    public byte[] PasswordSalt { get; set; } = new byte[128];

    [Column("reset_pass_token", TypeName = "Binary"), MaxLength(128)]
    public string? ResetPasswordToken { get; set; }

    [Column("role")]
    public UserRoles Role { get; set; } = UserRoles.PURCHASER;

    [Column("reset_pass_token_expire_date")]
    public DateTime? ResetPasswordTokenExpires { get; set; }

    [Column("sms_2step_code")]
    public uint? SMS_Code { get; set; }

    [Column("token_2step_code")]
    public uint? Token_Code { get; set; }

    [Column("email_2step_code")]
    public uint? Email_Code { get; set; }


    [ForeignKey("Role")]
    public Role? Roles { get; set; }

    public UserInfo? UserInfo { get; set; } = new UserInfo { CreateDate = DateTime.UtcNow, PhoneNumber_Verified = false, };

    public ICollection<UserAuthMethod>? UserAuthMethods { get; set; } = new Collection<UserAuthMethod> {
         new UserAuthMethod {AuthProviderID = AuthProvider.Providers.EMAIL}};

    public ICollection<UserVerificationMethod>? UserVerificationMethods { get; set; }

    public ICollection<UserAddress>? UserAddress { get; set; }

    public ICollection<Cart>? Cart { get; set; }

    public ICollection<Payment>? Payment { get; set; }

    public ICollection<UserReview>? UserReview { get; set; }

    public ICollection<Order>? Order { get; set; }
  }
}