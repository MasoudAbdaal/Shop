
using Shop.Models;

namespace Shop.Data.Interface
{

  public interface IAddressRepo
  {
    byte[]? GetUserID(string email);
    uint? CheckRegionExist(string regionName);
    Task<bool> DeleteAddress(byte[] addressID, byte[] userId);

    Task SaveChanges();
    Task<IEnumerable<Address>?> GetUserAddresses(byte[] userId);
    Task<IEnumerable<Region>> GetRegions();
    Task<Address?> AddAddress(Address newAddress, byte[] userId);
    Task<Address?> GetAddressByID(byte[] addressId);
    Task<Address?> ModifyAddress(Address newAddress, Address OldAddress);
  }

}
