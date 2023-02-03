using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{

  public class Role
  {
    public enum UserRoles : byte
    {
      ADMIN, SELLER, PURCHASER
    }

    [Key, Column("id")]
    public UserRoles ID { get; set; }

    [Column("name"), MaxLength(40)]
    public string? Name { get; set; }

    public List<User>? Users { get; set; }
  }
}