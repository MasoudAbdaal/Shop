using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DTOs
{
  public class UserRegisterDTO
  {

    [Required, Column("user_name"), MaxLength(40)]
    public string Name { get; set; } = string.Empty;

    [Required, Column("user_email"), EmailAddress, MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Column("user_birthdate")]
    public DateTime? BirthDate { get; set; }

    [Column("user_lastname"), MaxLength(40)]
    public string? LastName { get; set; }

    [Phone, Column("user_phone")]
    public string? PhoneNumber { get; set; }

  }
}