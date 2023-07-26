
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Address;


public class Region
{
    public Region(string Name)
    {
        this.Name = Name;
    }

    public uint RegionID { get; init; }

    public string? Name { get; init; }

    public uint? ParentID { get; init; }
    
    public Region? ParentRegion { get; set; }
    public ICollection<Region>? SubRegions { get; set; } = new List<Region>();
}
