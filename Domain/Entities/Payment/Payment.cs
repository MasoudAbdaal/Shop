using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Payment;


public class Payment
{
    public uint ID { get; set; }

    public byte[] UserID { get; set; } = new byte[16];

    public byte PaymentTypeID { get; set; }

    public Domain.Entities.User.User? User { get; set; }
    public PaymentType? PaymentType { get; set; }
    public ICollection<Domain.Entities.Order.Order>? Order { get; set; }
}
