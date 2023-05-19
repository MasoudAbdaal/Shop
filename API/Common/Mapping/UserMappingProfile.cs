using AutoMapper;
using Contracts.DTOs.User;
using Domain.Entities.User;

namespace Shop.Profiles
{
    public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<User, UserPresentationDTO>()
      .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserInfo!.PhoneNumber));

      CreateMap<UserModifyDTO, User>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Mail));

      CreateMap<UserInfo, UserInfoDTO>();
      CreateMap<UserInfoDTO, UserInfo>();
      CreateMap<UserAuthMethod, UserAuthMethodDTO>();

      CreateMap<UserRegisterDTO, User>();
    }
  }
}