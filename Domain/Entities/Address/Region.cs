
namespace Domain.Entities.Address;


public class Region
{
    public uint RegionID { get; set; }

    public string? Name { get; set; }

    public uint? ParentID { get; set; }
    // public Region? Parent { get; set; }
    public ICollection<Region>? SubRegions { get; set; } = new List<Region>();
}
