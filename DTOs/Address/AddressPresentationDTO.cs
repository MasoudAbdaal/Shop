

using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Shop.DTOs
{
  public class AddressPresentationDTO
  {
    public string? Region { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    public ushort Unit { get; set; }

    [MaxLength(100)]
    public string Address { get; set; } = string.Empty;

    public Point? GeoInfo { get; set; }
  }

}