namespace Domain.Entities.Order;

public class OrderStatus
{
    public enum StatusTypes : byte
    {
        WAIT_FOR_ACCEPT,
        DELIVERED
    }
    public StatusTypes ID { get; set; }

    public string? Status { get; set; }

    public ICollection<Order>? Orders { get; set; }
}
