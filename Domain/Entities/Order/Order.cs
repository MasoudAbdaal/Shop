
using static Domain.Entities.Order.OrderShippingMethod;
using static Domain.Entities.Order.OrderStatus;

namespace Domain.Entities.Order;

public class Order
{
    public byte[] ID { get; set; } = new byte[32];

    public byte[]? UserID { get; set; } = new byte[16];

    public uint TransactionID { get; set; }

    public byte[] AddressID { get; set; } = new byte[4];

    public DateTime? Date { get; set; }

    public decimal Total { get; set; }

    public StatusTypes OrderStatusID { get; set; }

    public ShippingMethods OrderShippingMethodID { get; set; }

    public Domain.Entities.User.User? User { get; set; }
    public Domain.Entities.Address.Address? Address { get; set; }
    public OrderStatus? OrderStatus { get; set; }
    public OrderShippingMethod? OrderShippingMethod { get; set; }
    public ICollection<OrderLine>? OrderLines { get; set; }
    public ICollection<Transaction.Transaction>? Transactions { get; set; }
}
