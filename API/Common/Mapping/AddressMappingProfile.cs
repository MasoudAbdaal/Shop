using AutoMapper;
using Contracts.DTOs.Address;
using Domain.Entities.Address;
using NetTopologySuite.Geometries;

namespace API.Common.Mapping;

public class AddressProfile : Profile
{

    public AddressProfile()
    {
        CreateMap<Address, AddressPresentationDTO>()
        .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src!.Region!.Name!.ToString()))
        .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.UnitNumber))
        .ForMember(dest => dest.AddressID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.GeoInfo, opt => opt.MapFrom(src => new GeoPointDTO { X = src.Location!.X, Y = src.Location.Y }));

        CreateMap<AddressPresentationDTO, Address>()
        .ForMember(dest => dest.Region, opt => opt.MapFrom(src => new Region { Name = src!.Region }))
        .ForMember(dest => dest.UnitNumber, opt => opt.MapFrom(src => src.Unit))
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.AddressID))
        .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Point(src.GeoInfo!.X, src.GeoInfo.Y) { SRID = 4326 }));


        CreateMap<AddressCreateDTO, Address>()
        .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Point(src.GeoInfo!.X, src.GeoInfo.Y) { SRID = 4326 }))
        .ForMember(dest => dest.Region, opt => opt.MapFrom(src => new Region { Name = src.RegionName }))
        .ForMember(dest => dest.UnitNumber, opt => opt.MapFrom(src => src.Unit));
    }

}