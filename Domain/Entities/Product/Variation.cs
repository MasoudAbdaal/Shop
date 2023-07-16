using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Product
{

    public class Variation
    {
        public enum Variations : byte
        {
            Size, Colour
        }

        [Column("id"), Key, Required]
        public ushort ID { get; set; }

        [ForeignKey(nameof(Category)), Column("category_id"),]
        public ushort? CategoryID { get; set; }

        [Column("name"), MaxLength(20)]
        public string? Name { get; set; }

        public Category? Category { get; set; }
        public ICollection<VariationOption>? VariationOptions { get; set; }
    }

    public class VariationOption
    {
        [Column("id"), Key, Required]
        public ushort ID { get; set; }

        [ForeignKey(nameof(Variation)), Column("variation_id")]
        public ushort? VariationID { get; set; }

        [Column("value"), MaxLength(20)]
        public string? Value { get; set; }

        public Variation? Variation { get; set; }
        public ICollection<ProductConf>? ProductConfs { get; set; }
    }
}