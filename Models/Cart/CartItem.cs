using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class CartItem
  {
    [Key, Column("id")]
    public uint ID { get; set; }

    [ForeignKey("Cart"), Column("cart_id")]
    public uint CartID { get; set; }

    [ForeignKey("ProductItem"), Column("product_item_id")]
    public byte ProductItemID { get; set; }

    [Column("quantity")]
    public ushort Quantity { get; set; }

    public Cart? Cart { get; set; }
    public ProductItem? ProductItem { get; set; }
  }
}