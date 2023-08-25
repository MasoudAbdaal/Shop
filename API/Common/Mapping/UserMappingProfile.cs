using AutoMapper;
using Contracts.DTOs.User;
using Domain.Entities.User;

namespace API.Common.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserPresentationDTO>()
        .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserInfo!.PhoneNumber))
        .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Email))
        // .ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.UserInfo))
        .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.UserRoleID.ToString()))
        .ForMember(dest => dest.AuthenticationMethods, opt => opt.MapFrom(src => src.UserAuthMethods));

        CreateMap<UserModifyDTO, User>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Mail));

        CreateMap<UserInfo, UserInfoDTO>();
        CreateMap<UserInfoDTO, UserInfo>();
        CreateMap<UserAuthMethod, UserAuthMethodDTO>();

        CreateMap<UserRegisterDTO, User>();
    }
}