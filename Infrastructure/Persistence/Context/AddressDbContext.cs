using System.Collections;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Contracts.Constants;
using Contracts.DbContexts;
using Domain.Entities.Address;
using Domain.Entities.User;
using Infrastructure;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

internal sealed class AddressDbContext : ModuleDbContext, IAddressDbContext
{
    protected override string Schema => "Shop";
    //this Should REMOVE!
    private MainContext? _context { get; set; }

    private IAddressDbContext? _addressContext { get; set; }

    //Create Interface And SeprateDbContext For this Entity!
    private IRegionDbContext? _regionContext { get; set; }
    private IUserDbContext? _userContext { get; set; }
    public DbSet<Address>? Addresses { get; set; }

    public AddressDbContext(DbContextOptions options, IRegionDbContext regionContext, IAddressDbContext addressContext, DbSet<Address>? addresses, IUserDbContext? userContext) : base(options)
    {
        _regionContext = regionContext;
        _addressContext = addressContext;
        Addresses = addresses;
        _userContext = userContext;
    }


    public bool DeleteAddress(byte[] addressID)
    {

        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Region>> GetRegions()
    {
        if (_regionContext!.Regions!.Count() < 1)
        {
            await _regionContext!.Regions!.AddAsync(Countries.USA);
            await _regionContext!.Regions!.AddAsync(Countries.IRAN);
            await SaveChangesAsync();

        }

        return await _regionContext!.Regions!.ToListAsync();
    }

    public async Task<IEnumerable<Address>?> GetUserAddresses(byte[] userId)
    {
        List<Address> AddressList = new List<Address>();

        List<byte[]> AddressIDs = _context.User_Addressess!.Where(j => j.UserID == userId)
        .Select(x => x.AddressID).AsNoTracking().ToList();

        foreach (byte[] ID in AddressIDs)
        {

            //IDK Why Regions IS NULL!!
            Address? Address = await _context.Address!.FindAsync(ID);
            Address!.Region = await _regionContext!.Regions!.FindAsync(Address.RegionID);

            AddressList.Add(Address!);
        }

        return AddressList;
    }

    public byte[]? GetUserID(string email)
    {
        byte[] uid = _context.Users!.Where(x => x.Email == email)
        .Select(i => i.ID).AsNoTracking().ToArray()[0];

        if (uid.Length < 1)
            return null;
        return uid;
    }

    public async Task<Address?> AddAddress(Address newAddress, byte[] userId)
    {
        await _context.User_Addressess!.AddAsync(new UserAddress { AddressID = newAddress.ID, UserID = userId, Address = newAddress });
        await SaveChangesAsync();

        return await GetAddressByID(newAddress.ID);
    }

    public async Task<Address?> ModifyAddress(Address newAddress, Address OldAddress)
    {
        Address? Modified = GeneralUtil.ApplyChanges(OldAddress, newAddress)!;
        if (Modified is not null)
        {
            _context.Address!.Update(Modified);
            await SaveChangesAsync();

            return OldAddress;
        }
        return default;
    }

    public async Task<bool> DeleteAddress(byte[] addressID, byte[] userId)
    {
        UserAddress? Address = await _context.User_Addressess!.FindAsync(userId, addressID);

        if (Address is null)
            return false;

        _context.User_Addressess.Remove(Address);
        _context.Address!.Remove(Address.Address!);
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
        return await _context.Address!.FindAsync(addressId);
    }


}