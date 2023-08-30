using Microsoft.EntityFrameworkCore;

using Contracts.Constants;
using Contracts.DbContexts;
using Domain.Entities.Address;
using Domain.Entities.User;
using Infrastructure.Common;
namespace Infrastructure.Persistence.Context;

internal sealed class AddressDbContext : ModuleDbContext, IAddressDbContext
{
    public DbSet<Address>? Addresses { get; set; }

    private IRegionDbContext? _regionContext { get; set; }
    private IUserAddressDbContext? _userAddressContext { get; set; }
    // private IUserDbContext? _userContext { get; set; }

    public AddressDbContext(DbContextOptions<AddressDbContext> options) : base(options)
    {
        Addresses = Set<Address>();
    }

    public AddressDbContext(
        DbContextOptions<AddressDbContext> options, IRegionDbContext regionContext,
        //  IUserDbContext? userContext,
        IUserAddressDbContext? userAddressContext) : base(options)
    {
        _regionContext = regionContext;
        // _userContext = userContext;
        _userAddressContext = userAddressContext;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);



    public bool DeleteAddress(byte[] addressID)
    {

        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Region>> GetRegions() => await _regionContext!.Regions!.ToListAsync();


    public async Task<IEnumerable<Address>?> GetUserAddresses(byte[] userId)
    {
        List<Address> AddressList = new List<Address>();

        List<byte[]> AddressIDs = _userAddressContext!.UserAddresses!
        .Where(j => j.UserID == userId)
        .Select(x => x.AddressID)
        .AsNoTracking()
        .ToList();

        foreach (byte[] ID in AddressIDs)
        {

            //IDK Why Regions IS NULL!!
            Address? Address = await Addresses!.FindAsync(ID);
            Address!.Region = await _regionContext!.Regions!.FindAsync(Address.RegionID);

            AddressList.Add(Address!);
        }

        return AddressList;
    }

    // public byte[]? GetUserID(string email)
    // {
    //     byte[] uid = _userContext!.Users!.Where(x => x.Email == email)
    //     .Select(i => i.ID).AsNoTracking().ToArray()[0];

    //     if (uid.Length < 1)
    //         return null;
    //     return uid;
    // }

    public async Task<Address?> AddAddress(Address newAddress, byte[] userId)
    {
        await _userAddressContext!.UserAddresses!.AddAsync(new UserAddress { AddressID = newAddress.ID, UserID = userId, Address = newAddress });
        await SaveChangesAsync();

        return await GetAddressByID(newAddress.ID);
    }

    public async Task<Address?> ModifyAddress(Address newAddress, Address OldAddress)
    {
        Address? Modified = GeneralUtil.ApplyChanges(OldAddress, newAddress)!;
        if (Modified is not null)
        {
            Addresses!.Update(Modified);
            await SaveChangesAsync();

            return OldAddress;
        }
        return default;
    }

    public async Task<bool> DeleteAddress(byte[] addressID, byte[] userId)
    {
        UserAddress? Address = await _userAddressContext!.UserAddresses!.FindAsync(userId, addressID);

        if (Address is null)
            return false;

        _userAddressContext.UserAddresses.Remove(Address);
        Addresses!.Remove(Address.Address!);
        await SaveChangesAsync();

        return true;
    }

    public uint? CheckRegionExist(string regionName)
    {
        List<uint> RegionID = _regionContext!.Regions!.Where(x => x.Name == regionName).Select(x => x.RegionID).ToList()!;
        if (RegionID.Capacity < 1)
            return null;

        else return RegionID[0];
    }

    public async Task<Address?> GetAddressByID(byte[] addressId)
    {
        return await Addresses!.FindAsync(addressId);
    }


}