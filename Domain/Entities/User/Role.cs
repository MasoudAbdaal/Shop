using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.User;

public class Role
{
    public enum UserRoles : uint
    {
        ADMIN, SELLER, PURCHASER
    }

    // [Key, Column("id")]
    public UserRoles ID { get; set; }

    // [Column("name"), MaxLength(50)]
    public string? Name { get; set; }

    public List<User>? Users { get; set; }
}
