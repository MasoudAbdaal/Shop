namespace Domain.Entities.Transaction;

public class Transaction
{
    public uint ID { get; set; }

    public byte[] OrderID { get; set; } = new byte[32];

    public byte[] UserID { get; set; } = new byte[16];

    public byte PaymentTypeID { get; set; }

    public bool IsSuccess { get; set; }

    public string? StatusDescription { get; set; }

    public DateTime Date { get; set; }

    public User.User? User { get; set; }
    public PaymentType? PaymentType { get; set; }
    public Order.Order? Order { get; set; }
}
