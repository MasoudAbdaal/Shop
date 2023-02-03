using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public enum UserRoles : byte
  {
    ADMIN, SELLER, PURCHASER
  }

  public class Role
  {
    [Key, Column("role_id")]
    public UserRoles ID { get; set; }

    [Column("role_name")]
    public string? Name { get; set; }

    public List<User>? Users { get; set; }
  }
}