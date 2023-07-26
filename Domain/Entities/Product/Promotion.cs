namespace Domain.Entities.Product;

public class Promotion
{
    public ushort ID { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public byte DiscountRate { get; set; }

    public DateTime DiscountStartDate { get; set; }

    public DateTime DiscountEndDate { get; set; }

    public ICollection<PromotionCategories>? PromotionCategories { get; set; }
    public ICollection<PromotionProducts>? PromotionProducts { get; set; }
}


public class PromotionCategories
{
    public ushort PromotionID { get; set; }

    public ushort CategoryID { get; set; }

    public Category? Category { get; set; }
    
    public Promotion? Promotion { get; set; }
}


public class PromotionProducts
{
    public byte ProductItemID { get; set; }

    public ushort PromotionID { get; set; }

    public Promotion? Promotion { get; set; }
    public ProductItem? ProductItem { get; set; }
}

