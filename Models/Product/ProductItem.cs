using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class ProductItem
  {
    [Column("id"), Key, Required, ConcurrencyCheck]
    public byte ID { get; set; }

    [ForeignKey(nameof(Product)), Column("product_id")]
    public uint ProductID { get; set; }

    [MaxLength(110000), Column("sku")]
    public byte[]? SKU { get; set; }

    [Column("quantity")]
    public uint Quantity { get; set; }

    [Column("price", TypeName = "Money")]
    public decimal Price { get; set; }

    public Product? Product { get; set; }
    public ICollection<ProductConf>? ProductConf { get; set; }
    public ICollection<CartItem>? CartItem { get; set; }
    public ICollection<OrderLine>? OrderLine { get; set; }
    public ICollection<PromotionProducts>? PromotionProduct { get; set; }
  }
}