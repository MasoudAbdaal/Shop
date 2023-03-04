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
      .ForMember(dest => dest.Phone, opt => opt.MapFrom(dest => dest.UserInfo!.PhoneNumber));
      
      CreateMap<UserInfo, UserInfoDTO>();
      CreateMap<UserAuthMethod, UserAuthMethodDTO>();

      CreateMap<UserRegisterDTO, User>();
    }
  }
}