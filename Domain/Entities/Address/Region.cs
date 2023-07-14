
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities.Address;


public class Region
{
    public uint RegionID { get; set; };

    public string? Name { get; set; }

    public uint? ParentID { get; set; }
    public Region? Parent { get; set; }
    public ICollection<Region>? SubRegions { get; init; } = new List<Region>();
}
