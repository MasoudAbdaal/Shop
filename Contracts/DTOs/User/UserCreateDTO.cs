using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.DTOs.User;

public class UserRegisterDTO
{

    [Required, MaxLength(40), MinLength(5)]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress, MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; set; }

    [Required, PasswordPropertyText]
    public string? Password { get; set; }

}