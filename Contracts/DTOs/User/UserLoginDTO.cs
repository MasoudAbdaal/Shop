using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.DTOs.User;

public class UserLoginDTO
{
    [Required, EmailAddress, MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; set; }

    [Required, PasswordPropertyText]
    public string? Password { get; set; }

}