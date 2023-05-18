using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities.Order;

public class Order
{
    [Key, Column("id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(32)]
    public byte[] ID { get; set; } = new byte[32];

    [ForeignKey(nameof(User)), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[]? User_ID { get; set; } = new byte[16];

    [ForeignKey(nameof(Payment)), Column("payment_method_id")]
    public uint PaymentMethodID { get; set; }

    [ForeignKey(nameof(Address)), Column("shipping_address")]
    public byte[] AddressID { get; set; } = new byte[4];

    [ForeignKey(nameof(OrderShippingMethod)), Column("shipping_method")]
    public byte ShippingMethod { get; set; }

    [ForeignKey(nameof(OrderStatus)), Column("status")]
    public byte Status { get; set; }

    [Column("ordered_date")]
    public DateTime? Date { get; set; }

    [Column("order_total", TypeName = "Money")]
    public decimal Total { get; set; }


    public Domain.Entities.User.User? User { get; set; }
    public Domain.Entities.Address.Address? Address { get; set; }
    public Domain.Entities.Payment.Payment? Payment { get; set; }
    public OrderStatus? OrderStatus { get; set; }
    public OrderShippingMethod? OrderShippingMethod { get; set; }
    public ICollection<OrderLine>? OrderLine { get; set; }
}
