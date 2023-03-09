using Shop.DTOs;
using Shop.Models;

namespace Shop.Data.Interface
{

  public interface IAddressRepo
  {
    Task SaveChanges();
    byte[]? GetUserID(string email);
    Task<IEnumerable<Address>?> GetUserAddresses(byte[] userId);
    Task<IEnumerable<Region>> GetRegions();
    uint? CheckRegionExist(string regionName);
    

    Task<Address?> GetAddressByID(byte[] addressId);

    Task<Address?> AddAddress(Address newAddress, byte[] userId);
    Task<Address?> ModifyAddress(Address newAddress);
    bool DeleteAddress(byte[] addressID);
  }

}
