namespace Domain.Entities.Product;

public class Product
{
    public uint ID { get; set; }

    public string Name { get; set; } = string.Empty;

    public ushort CategoryID { get; set; }

    public byte[]? Image { get; set; }

    public string Description { get; set; } = string.Empty;

    // public uint FullDescriptionID { get; set; }

    public Category? Category { get; set; }

    // public Description? Descriptions { get; set; }
    public ICollection<ProductItem>? ProductItems { get; set; }
}
