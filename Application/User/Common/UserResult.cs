using Contracts.DTOs.User;
using Domain.Entities.User;

public record UserResult
(
    string? Name,
    string? Mail,
    string? Phone,
    string? UserRole,
    UserInfo? Info
);
