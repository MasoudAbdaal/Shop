using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class Description
  {
    [Column("id"), Key, Required]
    public uint ID { get; set; }


    public Product? Product { get; set; }
  }
}