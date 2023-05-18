
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities.Address;


public class Region
{

    [Key, Required, Column("id")]
    public uint RegionID { get; set; }

    [Column("name"), MaxLength(20)]
    public string? Name { get; set; }

    [Column("parent_id")]
    public uint? ParentID { get; set; }

    [ForeignKey(nameof(ParentID))]
    // public Region? Regions { get; set; }
    public ICollection<Region>? SubRegion { get; set; }
}
