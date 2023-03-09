

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using NetTopologySuite.Geometries;
using Shop.Constants;
using Shop.Models;

namespace Shop.DTOs
{

  [AutoMap(typeof(Address))]
  public class AddressCreateDTO
  {
    [Required, EmailAddress, MinLength(8), Ignore]
    public string Mail { get; set; } = string.Empty;

    [Required]
    public string RegionName { get; set; } = Countries.USA.Name!;

    [Required, MaxLength(20)]
    public string? PostalCode { get; set; }

    [Required]
    public ushort Unit { get; set; }

    [Required, MaxLength(100)]
    public string? AddressLine { get; set; }

    public GeoPointDTO? GeoInfo { get; set; } = new GeoPointDTO { X = 35.65793, Y = 51.39779 };
  }
}