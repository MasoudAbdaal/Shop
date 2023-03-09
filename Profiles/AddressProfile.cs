using AutoMapper;
using NetTopologySuite.Geometries;
using Shop.DTOs;
using Shop.Models;

namespace Shop.Profiles
{
  public class AddressProfile : Profile
  {

    public AddressProfile()
    {
      CreateMap<Address, AddressPresentationDTO>()
      .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src!.Region!.Name!.ToString()))
      .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.UnitNumber))
      .ForMember(dest => dest.GeoInfo, opt => opt.MapFrom(src => src.Location!.ToString()));

      CreateMap<AddressCreateDTO, Address>()
      .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Point(src.GeoInfo!.X, src.GeoInfo.Y) { SRID = 4326 }))
      .ForMember(dest => dest.Region, opt => opt.MapFrom(src => new Region { Name = src.RegionName }))
      .ForMember(dest => dest.UnitNumber, opt => opt.MapFrom(src => src.Unit));
    }

  }
}