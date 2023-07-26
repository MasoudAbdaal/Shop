namespace Domain.Entities.Product;

public class Category
{
    public ushort ID { get; set; }

    public ushort? ParentID { get; set; }

    public string? Name { get; set; }

    public Category? ParentCategory { get; set; }
    public ICollection<Category>? SubCategories { get; set; }
    public ICollection<PromotionCategories>? PromotionCategories { get; set; }
    public ICollection<Product>? Products { get; set; }
    public ICollection<Variation>? Variations { get; set; }
}
