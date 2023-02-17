using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{

  public class Payment
  {
    [Key, Column("id")]
    public uint ID { get; set; }

    [ForeignKey("User"), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[] UserID { get; set; } = new byte[16];

    [ForeignKey("PaymentType"), Column("payment_type_id")]
    public byte PaymentTypeID { get; set; }

    public User? User { get; set; }
    public PaymentType? PaymentType { get; set; }
    public ICollection<Order>? Order { get; set; }
  }
}