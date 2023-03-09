using System.Collections;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Constants;
using Shop.Data;
using Shop.Data.Interface;
using Shop.DTOs;
using Shop.Models;
using Shop.Utility;

public class AddressRepo : IAddressRepo
{
  private readonly MainContext _context;
  private readonly IMapper _mapper;

  public AddressRepo(MainContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }


  public bool DeleteAddress(byte[] addressID)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<Region>> GetRegions()
  {
    if (_context.Regions.Count() < 1)
    {
      await _context.Regions.AddAsync(Countries.USA);
      await _context.Regions.AddAsync(Countries.IRAN);
      await SaveChanges();
    }

    return await _context.Regions.ToListAsync();
  }

  public async Task<IEnumerable<Address>?> GetUserAddresses(byte[] userId)
  {
    List<Address> AddressList = new List<Address>();

    List<byte[]> AddressIDs = _context.User_Addressess.Where(j => j.UserID == userId).Select(x => x.AddressID).ToList();

    foreach (byte[] ID in AddressIDs)
    {

      Address? Address = await _context.Address.FindAsync(ID);
      Address!.Region = await _context.Regions.FindAsync(Address.RegionID);

      AddressList.Add(Address!);
    }

    return AddressList;
  }

  public byte[]? GetUserID(string email)
  {
    byte[] uid = _context.Users.Where(x => x.Email == email).Select(i => i.ID).ToArray()[0];
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
    await _context.User_Addressess.AddAsync(new UserAddress { AddressID = newAddress.ID, UserID = userId, Address = newAddress });
    await SaveChanges();

    return await GetAddressByID(newAddress.ID);
  }

  public async Task<Address?> ModifyAddress(Address newAddress, Address OldAddress)
  {
    Address? Modified = GeneralUtil.ApplyChanges(OldAddress, newAddress)!;
    if (Modified is not null)
    {
      _context.Address.Update(Modified);
      await SaveChanges();

      return OldAddress;
    }
    return default;
  }


  public uint? CheckRegionExist(string regionName)
  {
    List<uint> RegionID = _context.Regions.Where(x => x.Name == regionName).Select(x => x.RegionID).ToList()!;
    if (RegionID.Capacity < 1)
      return null;

    else return RegionID[0];
  }

  public async Task<Address?> GetAddressByID(byte[] addressId)
  {
    return await _context.Address.FindAsync(addressId);
  }
}