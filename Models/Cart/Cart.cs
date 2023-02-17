using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class Cart
  {
    [Key, Column("id")]
    public uint ID { get; set; }

    [Column("name"), MaxLength(30)]
    public string? Name { get; set; }

    [ForeignKey("User"), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[] UserID { get; set; } = new byte[16];

    public User? User { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }
  }
}