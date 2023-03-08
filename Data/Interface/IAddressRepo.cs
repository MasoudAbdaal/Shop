using Shop.DTOs;
using Shop.Models;

namespace Shop.Data.Interface
{

  public interface IAddressRepo
  {
    Task SaveChanges();
    byte[]? GetUserID(string email);
    Task<Address?> AddAddress();
    Task<IEnumerable<Address>?> GetUserAddresses(byte[] userId);
    bool DeleteAddress(byte[] addressID);
    Task<IEnumerable<Region>> GetRegions();
  }

}
