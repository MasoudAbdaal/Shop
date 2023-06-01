using AutoMapper;
using Contracts.DbContext;
using Infrastructure.Context;
using Infrastructure.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
  private readonly MainContext _context;

  private readonly Lazy<IAuthRepo> _authRepo;
  private readonly Lazy<IAddressRepo> _addressRepo;
  private readonly Lazy<IUserRepo> _userRepo;

  public RepositoryManager(MainContext context)
  {
    _context = context;

    _authRepo = new Lazy<IAuthRepo>(() => new AuthRepo(context));
    _addressRepo = new Lazy<IAddressRepo>(() => new AddressRepo(context));
    _userRepo = new Lazy<IUserRepo>(() => new UserRepo(context, null!));

  }

  public IAuthRepo Auth => _authRepo.Value;
  public IAddressRepo Address => _addressRepo.Value;
  public IUserRepo User => _userRepo.Value;

  public void Save() => _context.SaveChanges();

}