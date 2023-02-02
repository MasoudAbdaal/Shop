using AutoMapper;
using Shop.DTOs;
using Shop.Models;

namespace Shop.Profiles
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<UserRegisterDTO, User>();
    }
  }
}