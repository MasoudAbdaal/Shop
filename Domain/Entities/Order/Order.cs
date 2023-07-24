
namespace Domain.Entities.Order;

public class Order
{
    public byte[] ID { get; set; } = new byte[32];

    public byte[]? UserID { get; set; } = new byte[16];

    public uint TransactionID { get; set; }

    public byte[] AddressID { get; set; } = new byte[4];

    public byte ShippingMethod { get; set; }

    public byte Status { get; set; }

    public DateTime? Date { get; set; }

    public decimal Total { get; set; }

    public Domain.Entities.User.User? User { get; set; }
    public Domain.Entities.Address.Address? Address { get; set; }
    public OrderStatus? OrderStatus { get; set; }
    public OrderShippingMethod? OrderShippingMethod { get; set; }
    public ICollection<OrderLine>? OrderLines { get; set; }
    public ICollection<Transaction.Transaction>? Transactions { get; set; }
}
