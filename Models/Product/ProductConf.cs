using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
  public class ProductConf
  {
    [Column("variation_option_id")]
    public ushort? VariationOptionID { get; set; }

    [Column("product_item_id")]
    public byte? ProductItemID { get; set; }

    [ForeignKey("VariationOptionID")]
    public VariationOption? VariationOptions { get; set; }
    [ForeignKey("ProductItemID")]
    public ProductItem? ProductItems { get; set; }
  }
}