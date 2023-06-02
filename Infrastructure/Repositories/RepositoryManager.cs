// using AutoMapper;
// using Contracts.DbContext;
// using Infrastructure.Context;
// using Infrastructure.Repositories;

// public sealed class RepositoryManager : IRepositoryManager
// {
//   private readonly MainContext _context;

//   private readonly Lazy<IAuthRepo> _authRepo;
//   private readonly Lazy<IAddressRepo> _addressRepo;
// //   private readonly Lazy<IUserDbContext> _userRepo;

//   public RepositoryManager(MainContext context)
//   {
//     _context = context;

//     _authRepo = new Lazy<IAuthRepo>(() => new AuthRepo(context));
//     _addressRepo = new Lazy<IAddressRepo>(() => new AddressRepo(context));
//     // _userRepo = new Lazy<IUserDbContext>(() => new UserRepo(context, null!));

//   }

//   public IAuthRepo Auth => _authRepo.Value;
//   public IAddressRepo Address => _addressRepo.Value;
// //   public IUserDbContext User => _userRepo.Value;

//   public void Save() => _context.SaveChanges();

// }