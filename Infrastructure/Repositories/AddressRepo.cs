using System.Collections;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Contracts.Constants;
using Contracts.DbContext;
using Domain.Entities.Address;
using Domain.Entities.User;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

internal sealed class AddressRepo : RepositoryBase<Address>, IAddressRepo
{
    private readonly MainContext _context;

    public AddressRepo(MainContext context) : base(context)
    {
        _context = context;
    }


    public bool DeleteAddress(byte[] addressID)
    {

        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Region>> GetRegions()
    {
        if (_context.Regions!.Count() < 1)
        {
            await _context.Regions!.AddAsync(Countries.USA);
            await _context.Regions!.AddAsync(Countries.IRAN);
            await SaveChanges();
        }

        return await _context.Regions!.ToListAsync();
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
            Address!.Region = await _context.Regions!.FindAsync(Address.RegionID);

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

    public Task SaveChanges()
    {
        return _context.SaveChangesAsync();
    }

    public async Task<Address?> AddAddress(Address newAddress, byte[] userId)
    {
        await _context.User_Addressess!.AddAsync(new UserAddress { AddressID = newAddress.ID, UserID = userId, Address = newAddress });
        await SaveChanges();

        return await GetAddressByID(newAddress.ID);
    }

    public async Task<Address?> ModifyAddress(Address newAddress, Address OldAddress)
    {
        Address? Modified = GeneralUtil.ApplyChanges(OldAddress, newAddress)!;
        if (Modified is not null)
        {
            _context.Address!.Update(Modified);
            await SaveChanges();

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
        await SaveChanges();

        return true;
    }

    public uint? CheckRegionExist(string regionName)
    {
        List<uint> RegionID = _context.Regions!.Where(x => x.Name == regionName).Select(x => x.RegionID).ToList()!;
        if (RegionID.Capacity < 1)
            return null;

        else return RegionID[0];
    }

    public async Task<Address?> GetAddressByID(byte[] addressId)
    {
        return await _context.Address!.FindAsync(addressId);
    }


}