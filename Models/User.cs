using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{

  [Index(nameof(ID), IsUnique = true, Name = "Index_ID")]
  public class User
  {

    public enum TwoStepTypes
    {
      NONE, SMS, EMAIL, TOKEN, SMS_AND_EMAIL
    }

    public enum UserRoles
    {
      ADMIN, SELLER, PURCHASER
    }

    public enum AuthProviders
    {
      NONE, GOOGLE, FACEBOOK, MICROSOFT
    }

    [Required, Key, Column("user_id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(16)]
    public byte[] ID { get; set; } = new byte[16];

    [Required, Column("user_name"), MaxLength(40)]
    public string Name { get; set; } = string.Empty;

    [Required, Column("user_email"), EmailAddress, MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Column("is_email_verified")]
    public bool Email_Verified { get; set; } = false;


    [Required, Column("user_password", TypeName = "Binary"), MaxLength(64)]
    public byte[] Password { get; set; } = new byte[64];

    [Required, Column("user_password_salt", TypeName = "Binary"), MaxLength(128),]
    public byte[] PasswordSalt { get; set; } = new byte[128];

    [Column("account_enabled")]
    public bool Enabled { get; set; } = true;

    [Column("failed_login_attempts_count")]
    public byte FailedLoginAttempts { get; set; } = 0;

    [Column("authentication_providers")]
    public AuthProviders AuthProvider = AuthProviders.NONE;

    [Column("user_role")]
    public UserRoles Role = UserRoles.PURCHASER;

    [Column("two_steps_verification_methods")]
    public TwoStepTypes TwoStepMethods = TwoStepTypes.NONE;

    [Column("is_phone_verified")]
    public bool PhoneNumber_Verified { get; set; } = false;

    //DB TRIGGER
    [Column("user_createdate")]
    public DateTime? CreateDate { get; set; }

    [Column("user_birthdate")]
    public DateTime? BirthDate { get; set; }

    [Column("user_lastname"), MaxLength(40)]
    public string? LastName { get; set; }

    [Column("verified_date")]
    public DateTime? VerifiedDate { get; set; }

    [Phone, Column("user_phone")]
    public string? PhoneNumber { get; set; }

    [Column("reset_pass_token")]
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