using Domain.Entities.Product;

namespace Domain.Entities.Cart;

public class CartItem
{
    public uint ID { get; set; }

    public uint CartID { get; set; }

    public byte ProductItemID { get; set; }

    public ushort Quantity { get; set; }

    public Cart? Cart { get; set; }
    public ProductItem? ProductItem { get; set; }
}
