using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
  [Index(nameof(ID), IsUnique = true)]
  public class Product
  {
    [Column("id"), Key, Required, ConcurrencyCheck]
    public uint ID { get; set; }

    [Column("name"), Required, MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    [ForeignKey("Category"), Column("category_id"), Required]
    public ushort CategoryID { get; set; }

    [Column("image"), Required]
    public byte[]? Image { get; set; }

    [Column("description"), Required, MaxLength(128)]
    public string Description { get; set; } = string.Empty;

    [Column("full_description_id")]
    public uint FullDescriptionID { get; set; }

    public Category? Category { get; set; }
    [ForeignKey("FullDescriptionID")]
    public Description? Descriptions { get; set; }
    public ICollection<ProductItem>? ProductItem { get; set; }
  }
}