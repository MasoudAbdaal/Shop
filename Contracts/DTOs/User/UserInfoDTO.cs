namespace Contracts.DTOs.User;

public class UserInfoDTO
{
    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumber_Verified { get; set; }

    public bool Email_Verified { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? BirthDate { get; set; }
}