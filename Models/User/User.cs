using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Shop.Models.AuthProvider;
using static Shop.Models.Role;

namespace Shop.Models
{

  [Index(nameof(ID), IsUnique = true, Name = "Index_ID")]
  public class User
  {

    public enum TwoStepMethods
    {
      NONE, SMS, EMAIL, TOKEN, SMS_AND_EMAIL
    }

    [Key, Required, Column("id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(16)]
    public byte[] ID { get; set; } = new byte[16];

    [Required, Column("name"), MaxLength(40)]
    public string Name { get; set; } = string.Empty;

    [Required, Column("email"), EmailAddress, MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Column("is_email_verified")]
    public bool Email_Verified { get; set; } = false;

    [Required, Column("password", TypeName = "Binary"), MaxLength(64)]
    public byte[] Password { get; set; } = new byte[64];

    [Required, Column("password_salt", TypeName = "Binary"), MaxLength(128),]
    public byte[] PasswordSalt { get; set; } = new byte[128];

    [Column("account_enabled")]
    public bool Enabled { get; set; } = true;

    [Column("failed_login_attempts_count")]
    public byte FailedLoginAttempts { get; set; } = 0;

    public ICollection<UserAuthMethod>? UserAuthMethods { get; set; }

    [Column("role")]
    public UserRoles Role { get; set; }
    [ForeignKey("Role")]
    public Role? Roles { get; set; }

    [Column("two_steps_verification_methods")]
    public TwoStepMethods TwoStepMethod { get; set; }

    [Column("is_phone_verified")]
    public bool PhoneNumber_Verified { get; set; } = false;

    //DB TRIGGER
    [Column("createdate")]
    public DateTime? CreateDate { get; set; }

    [Column("birthdate")]
    public DateTime? BirthDate { get; set; }

    [Column("lastname"), MaxLength(40)]
    public string? LastName { get; set; }

    [Column("verified_date")]
    public DateTime? VerifiedDate { get; set; }

    [Phone, Column("phone"), MaxLength(15)]
    public string? PhoneNumber { get; set; }

    [Column("reset_pass_token"), MaxLength(128)]
    public string? ResetPasswordToken { get; set; }

    [Column("reset_pass_token_expire_date")]
    public DateTime? ResetPasswordTokenExpires { get; set; }

    [Column("sms_2step_code")]
    public uint? SMS_Code { get; set; }

    [Column("token_2step_code")]
    public uint? Token_Code { get; set; }

    [Column("email_2step_code")]
    public uint? Email_Code { get; set; }
  }
}