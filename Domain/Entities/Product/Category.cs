using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Product;

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
    public ICollection<Category>? SubCategories { get; set; }
    public ICollection<PromotionCategories>? PromotionCategories { get; set; }

    public ICollection<Product>? Products { get; set; }
    public ICollection<Variation>? Variations { get; set; }
}
