using System.Collections;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Constants;
using Shop.Data;
using Shop.Data.Interface;
using Shop.DTOs;
using Shop.Models;

public class AddressRepo : IAddressRepo
{
  private readonly MainContext _context;
  private readonly IMapper _mapper;

  public AddressRepo(MainContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public Task<Address?> AddAddress()
  {
    throw new NotImplementedException();
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

      AddressList.Add(Address!);
    }

    return AddressList;
  }

  public byte[]? GetUserID(string email)
  {
    byte[][] uid = _context.Users.Where(x => x.Email == email).Select(i => i.ID).ToArray();
    if (uid.Length < 1)
      return null;
    return uid[0];
  }

  public Task SaveChanges()
  {
    return _context.SaveChangesAsync();
  }
}