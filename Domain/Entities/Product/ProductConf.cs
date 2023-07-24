namespace Domain.Entities.Product;

public class ProductConf
{
    public ushort? VariationOptionID { get; set; }

    public byte? ProductItemID { get; set; }

    public VariationOption? VariationOption { get; set; }
    public ProductItem? ProductItem { get; set; }
}
