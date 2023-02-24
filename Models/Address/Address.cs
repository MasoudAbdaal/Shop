using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Shop.Models
{

  public class Address
  {
    [Key, Required, Column("id"), MaxLength(4), DatabaseGenerated(DatabaseGeneratedOption.None)]
    public byte[] ID { get; set; } = new byte[4];

    [ForeignKey("Region"), Column("region_id")]
    public uint RegionID { get; set; }

    [Column("postal_code"), MaxLength(20)]
    public string? PostalCode { get; set; }

    [Column("unit_number")]
    public ushort UnitNumber { get; set; }

    [Column("address_line"), MaxLength(100)]
    public string AddressLine { get; set; } = string.Empty;

    [Column("location")]
    public Point? Location { get; set; }

    [Column("location_address"), MaxLength(100)]
    public string? LocationAddress { get; set; }

    public Region? Region { get; set; }
    public ICollection<UserAddress>? UserAddress { get; set; }
    public ICollection<Order>? Order { get; set; }

  }
}