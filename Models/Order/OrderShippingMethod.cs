using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class OrderShippingMethod
  {
    public enum Methods : byte
    {
      POST, EXPRESS
    }

    [Key, Column("id")]
    public byte? ID { get; set; }

    [Column("name")]
    public Methods Name { get; set; }

    [Column("price", TypeName = "Money")]
    public decimal Price { get; set; }

    public ICollection<Order>? Order { get; set; }
  }
}