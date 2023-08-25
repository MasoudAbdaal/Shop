using Contracts.DTOs.User;
using Domain.Entities.User;

public record UserResult
{
    public string? Name { get; init; }

    public string? Mail { get; init; }

    public string? Phone { get; init; }

    public string? UserRole { get; init; }

    public UserInfo? Info { get; init; }

}
