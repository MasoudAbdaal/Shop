using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Cart;

public class Cart
{
    [Key, Column("id")]
    public uint ID { get; set; }

    [Column("name"), MaxLength(30)]
    public string? Name { get; set; }

    [ForeignKey(nameof(User)), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[] UserID { get; set; } = new byte[16];

    public Domain.Entities.User.User? User { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }
}
