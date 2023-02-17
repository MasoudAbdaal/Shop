using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class PaymentType
  {
    [Key, Column("id")]
    public byte ID { get; set; }

    [Column("value"), MaxLength(20)]
    public string? Value { get; set; }

    public ICollection<Payment>? Payment { get; set; }
  }
}