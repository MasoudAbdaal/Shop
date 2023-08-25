using Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace Contracts.DbContexts;

public interface IAddressDbContext
{
    DbSet<Address>? Addresses { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    byte[]? GetUserID(string email);
    uint? CheckRegionExist(string regionName);

    Task<bool> DeleteAddress(byte[] addressID, byte[] userId);
    Task<IEnumerable<Address>?> GetUserAddresses(byte[] userId);
    Task<IEnumerable<Region>> GetRegions();
    Task<Address?> AddAddress(Address newAddress, byte[] userId);
    Task<Address?> GetAddressByID(byte[] addressId);
    Task<Address?> ModifyAddress(Address newAddress, Address OldAddress);
}
