using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DTOs
{
  public class UserRegisterDTO
  {

    [Required, Column("user_name"), MaxLength(40)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(40)]
    public string? LastName { get; set; }

    [Required, EmailAddress, MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; set; }

    public DateTime? BirthDate { get; set; }

  }
}