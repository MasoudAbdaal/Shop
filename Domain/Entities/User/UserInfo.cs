namespace Domain.Entities.User;

public class UserInfo
{
    public byte[]? UserID { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumber_Verified { get; set; } = false;

    public bool Enabled { get; set; } = true;

    public bool Email_Verified { get; set; } = false;

    public DateTime? VerifiedDate { get; set; }

    public DateTime CreatedDate { get; init; } = DateTime.UtcNow;

    public DateTime? BirthDate { get; set; }

    public byte FailedLoginAttempts { get; set; } = 0;

    public User? User { get; set; }
}
