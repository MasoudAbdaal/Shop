using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class OrderLine
  {
    [Key, Column("id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(32)]
    public byte[] ID { get; set; } = new byte[32];

    [ForeignKey("ProductItem"), Column("product_item_id"),]
    public byte ProductItemID { get; set; }


    [ForeignKey("Order"), Column("order_id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(32)]
    public byte[] OrderID { get; set; } = new byte[32];

    [Column("ordered_quantity")]
    public uint Quantity { get; set; }

    [Column("price", TypeName = "Money")]
    public decimal Price { get; set; }

    public ICollection<UserReview>? UserReview { get; set; }
    public ProductItem? ProductItem { get; set; }
    public Order? Order { get; set; }
  }
}