using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop.Models
{


  public class UserInfo
  {
    [ForeignKey(nameof(User)), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[] ID { get; set; } = new byte[16];

    [Column("lastname"), MaxLength(40)]
    public string? LastName { get; set; }

    [Phone, Column("phone"), MaxLength(15)]
    public string? PhoneNumber { get; set; }

    [Column("is_phone_verified")]
    public bool PhoneNumber_Verified { get; set; } = false;

    [Column("account_enabled")]
    public bool Enabled { get; set; } = true;

    [Column("is_email_verified")]
    public bool Email_Verified { get; set; } = false;

    [Column("verified_date")]
    public DateTime? VerifiedDate { get; set; }

    [Column("createdate")]
    public DateTime? CreateDate { get; set; }

    [Column("birthdate")]
    public DateTime? BirthDate { get; set; }

    [Column("failed_login_attempts_count")]
    public byte FailedLoginAttempts { get; set; } = 0;

    public User? User { get; set; }
  }
}