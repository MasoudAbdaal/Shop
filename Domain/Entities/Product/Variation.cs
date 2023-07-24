using static Domain.Entities.Product.Variation;

namespace Domain.Entities.Product;

public class Variation
{
    public enum Variations : byte
    {
        Size, Colour
    }

    public Variations ID { get; set; }
    
    public string? Name { get; set; }

    public ushort? CategoryID { get; set; }

    public Category? Category { get; set; }
    public ICollection<VariationOption>? VariationOptions { get; set; }
}

public class VariationOption
{
    public ushort ID { get; set; }

    public Variations? VariationID { get; set; }

    public string? Value { get; set; }

    public Variation? Variation { get; set; }
    public ICollection<ProductConf>? ProductConfs { get; set; }
}