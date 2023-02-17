using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class OrderStatus
  {
    public enum CurrentStatus : byte
    {
      WAIT_FOR_ACCEPT,
      DELIVERED
    }
    [Key, Column("id")]
    public byte? ID { get; set; }

    [Column("status")]
    public CurrentStatus Status { get; set; }

    public ICollection<Order>? Order { get; set; }
  }
}