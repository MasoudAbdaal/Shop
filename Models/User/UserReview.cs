using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class UserReview
  {
    [Key, Column("id")]
    public uint ID { get; set; }

    [ForeignKey("User"), Column("user_id", TypeName = "Binary"), MaxLength(16)]
    public byte[]? UserID { get; set; } = new byte[16];

    [ForeignKey("OrderLine"), Column("order_line_id", TypeName = "Binary"), ConcurrencyCheck, MaxLength(32)]
    public byte[] OrderLineID { get; set; } = new byte[32];

    [Column("rate"), MaxLength(5)]
    public byte? Rate { get; set; }

    [Column("comment"), MaxLength(512)]
    public string? Comment { get; set; }

    public User? User { get; set; }
    public OrderLine? OrderLine { get; set; }
  }
}