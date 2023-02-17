using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class Order
  {
    [Key, Column("id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(32)]
    public byte[] ID { get; set; } = new byte[32];

    [ForeignKey("User"), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[]? User_ID { get; set; } = new byte[16];

    [ForeignKey("Payment"), Column("payment_method_id")]
    public uint PaymentMethodID { get; set; }

    [ForeignKey("Address"), Column("shipping_address")]
    public uint AddressID { get; set; }

    [ForeignKey("OrderShippingMethod"), Column("shipping_method")]
    public byte ShippingMethod { get; set; }

    [ForeignKey("OrderStatus"), Column("status")]
    public byte Status { get; set; }

    [Column("ordered_date")]
    public DateTime? Date { get; set; }

    [Column("order_total", TypeName = "Money")]
    public decimal Total { get; set; }


    public User? User { get; set; }
    public Address? Address { get; set; }
    public Payment? Payment { get; set; }
    public OrderStatus? OrderStatus { get; set; }
    public OrderShippingMethod? OrderShippingMethod { get; set; }
    public ICollection<OrderLine>? OrderLine { get; set; }
  }
}