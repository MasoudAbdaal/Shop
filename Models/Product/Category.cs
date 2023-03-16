using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class Category
  {
    [Column("id"), Key, Required]
    public ushort ID { get; set; }

    [Column("parent_id")]
    public ushort? ParentID { get; set; }

    [Column("name"), MaxLength(20)]
    public string? Name { get; set; }

    [ForeignKey(nameof(ParentID))]
    public Category? Categories { get; set; }
    public ICollection<Category>? SubCategory { get; set; }
    public ICollection<PromotionCategories>? PromotionCategory { get; set; }

    public ICollection<Product>? Product { get; set; }
    public ICollection<Variation>? Variation { get; set; }
  }
}