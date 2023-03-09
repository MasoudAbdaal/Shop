

using System.ComponentModel.DataAnnotations;

namespace Shop.DTOs
{

  public class AddressPresentationDTO
  {
    public byte[] AddressID { get; set; } = new byte[4];

    public string? Region { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    public ushort Unit { get; set; }

    [MaxLength(100)]
    public string? AddressLine { get; set; }

    public GeoPointDTO? GeoInfo { get; set; } = new GeoPointDTO { X = 35.65793, Y = 51.39779 };
  }

}