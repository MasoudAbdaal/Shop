using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Cart;

public class Cart
{
    public uint ID { get; set; }

    public string? Name { get; set; }

    public byte[] UserID { get; set; } = new byte[16];

    public Domain.Entities.User.User? User { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }
}
