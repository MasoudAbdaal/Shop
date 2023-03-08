using AutoMapper;
using Shop.DTOs;
using Shop.Models;

namespace Shop.Profiles
{
  public class AddressProfile : Profile
  {

    public AddressProfile()
    {
      CreateMap<Address, AddressPresentationDTO>();
    }

  }
}