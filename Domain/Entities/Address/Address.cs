using NetTopologySuite.Geometries;
using Domain.Entities.User;

namespace Domain.Entities.Address;

public class Address
{
    public byte[] ID { get; set; } = new byte[4];

    public uint RegionID { get; set; }

    public string? PostalCode { get; set; }

    public ushort UnitNumber { get; set; }

    public string AddressLine { get; set; } = string.Empty;

    public Point? Location { get; set; }

    public string? LocationAddress { get; set; }

    public Region? Region { get; set; }
    public ICollection<UserAddress>? UserAddresses { get; set; }
    public ICollection<Domain.Entities.Order.Order>? Orders { get; set; }

}
