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
    Task<Address?> AddAddress(Address newAddress, byte[] userId);
    Task<Address?> GetAddressByID(byte[] addressId);
    Task<Address?> ModifyAddress(Address newAddress, Address OldAddress);
    bool DeleteAddress(byte[] addressID);
  }

}
