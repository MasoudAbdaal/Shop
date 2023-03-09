

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using NetTopologySuite.Geometries;
using Shop.Models;

namespace Shop.DTOs
{
  public class GeoPointDTO
  {
    public double X { get; set; }
    public double Y { get; set; }
  }

}