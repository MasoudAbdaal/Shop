using AutoMapper;
using Shop.DTOs;
using Shop.Models;

namespace Shop.Profiles
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<User, UserPresentationDTO>()
      .ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.UserInfo))
      .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Email))
      .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.Role))
      .ForMember(dest => dest.AuthenticationMethods, opt => opt.MapFrom(src => src.UserAuthMethods));

      CreateMap<UserInfo, UserInfoDTO>();
      CreateMap<UserAuthMethod, UserAuthMethodDTO>();

      CreateMap<UserRegisterDTO, User>();
    }
  }
}