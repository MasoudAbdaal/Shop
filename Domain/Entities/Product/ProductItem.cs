using Domain.Entities.Cart;
using Domain.Entities.Order;

namespace Domain.Entities.Product;

public class ProductItem
{
    public byte ID { get; set; }

    public uint ProductID { get; set; }

    public byte[]? SKU { get; set; }

    public uint Quantity { get; set; }

    public decimal Price { get; set; }

    public Product? Product { get; set; }
    public ICollection<ProductConf>? ProductConfs { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }
    public ICollection<OrderLine>? OrderLines { get; set; }
    public ICollection<PromotionProducts>? PromotionProducts { get; set; }
}
