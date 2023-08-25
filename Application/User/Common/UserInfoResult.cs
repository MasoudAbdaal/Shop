namespace Contracts.DTOs.User;

public record UserInfoResult
{
    public string? LastName { get; init; }

    public string? PhoneNumber { get; init; }

    public bool IsPhoneVerified { get; init; }

    public bool IsMailVerified { get; init; }

    public DateTime? CreateDate { get; init; }

    public DateTime? BirthDate { get; init; }
}