using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Product;
using Domain.Entities.User;

namespace Domain.Entities.Order;

public class OrderLine
{
    [Key, Column("id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(32)]
    public byte[] ID { get; set; } = new byte[32];

    [ForeignKey(nameof(ProductItem)), Column("product_item_id"),]
    public byte ProductItemID { get; set; }


    [ForeignKey(nameof(Order)), Column("order_id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(32)]
    public byte[] OrderID { get; set; } = new byte[32];

    [Column("ordered_quantity")]
    public uint Quantity { get; set; }

    [Column("price", TypeName = "Money")]
    public decimal Price { get; set; }

    public ICollection<UserReview>? UserReview { get; set; }
    public ProductItem? ProductItem { get; set; }
    public Order? Order { get; set; }
}
