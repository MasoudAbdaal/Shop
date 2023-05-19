using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Payment;


public class Payment
{
    [Key, Column("id")]
    public uint ID { get; set; }

    [ForeignKey(nameof(User)), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[] UserID { get; set; } = new byte[16];

    [ForeignKey(nameof(PaymentType)), Column("payment_type_id")]
    public byte PaymentTypeID { get; set; }

    public Domain.Entities.User.User? User { get; set; }
    public PaymentType? PaymentType { get; set; }
    public ICollection<Domain.Entities.Order.Order>? Order { get; set; }
}
