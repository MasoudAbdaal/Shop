using AutoMapper;
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
    }

  }
}