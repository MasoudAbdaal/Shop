using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class Promotion
  {
    [Column("id"), Key, Required]
    public ushort ID { get; set; }

    [Column("name"), MaxLength(20)]
    public string? Name { get; set; }

    [Column("description"), MaxLength(64)]
    public string? Description { get; set; }

    [Column("rate")]
    public byte DiscountRate { get; set; }


    [Column("start_date")]
    public DateTime? DiscountStartDate { get; set; }

    [Column("end_date")]
    public DateTime? DiscountEndDate { get; set; }

    public ICollection<PromotionCategory>? PromotionCategories { get; set; }
  }


  public class PromotionCategory
  {
    [ForeignKey("Promotion"), Column("promotion_id")]
    public ushort PromotionID { get; set; }

    [ForeignKey("Category"), Column("category_id")]
    public ushort CategoryID { get; set; }

    public Category? Category { get; set; }
    public Promotion? Promotion { get; set; }
  }
}