namespace Domain.Entities.Transaction;

public class PaymentType
{
    public byte ID { get; set; }

    public string? Name { get; set; }

    public ICollection<Transaction>? Transactions { get; set; }
}
