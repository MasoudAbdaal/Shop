

using System.ComponentModel.DataAnnotations;

namespace Shop.DTOs
{

  public class AddressPresentationDTO
  {

    public string? Region { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    public ushort Unit { get; set; }

    [MaxLength(100)]
    public string? AddressLine { get; set; }

    public string? GeoInfo { get; set; }
  }

}