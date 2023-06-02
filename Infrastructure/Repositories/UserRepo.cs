// using System.Reflection;
// using AutoMapper;
// using Contracts.DbContext;
// using Contracts.DTOs.User;
// using Domain.Entities.User;
// using Infrastructure.Context;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking;

// namespace Infrastructure.Repositories;


// internal sealed class UserRepo : RepositoryBase<User>, IUserDbContext
// {
//     private readonly IMapper _mapper;

//     public UserRepo(MainContext context, IMapper mapper) : base(context)
//     {
//         _mapper = mapper;
//     }

//     // DbSet<User> IUserRepo.Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
//     DbSet<User> IUserDbContext.Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//     public async Task<User?> EditUserInfo(User user, UserModifyDTO newInfo)
//     {

//         user!.Name = newInfo.Name.Length > 5 ? newInfo.Name : user.Name;

//         UserInfo Info = MainContext.User_Info!.Find(user.ID)!;
//         if (user != null)
//         {
//             Info = GeneralUtil.ApplyChanges(Info, _mapper.Map<UserInfoDTO, UserInfo>(newInfo.info!))!;
//             if (Info is not null)
//             {
//                 MainContext.User_Info.Update(Info!);
//                 MainContext.Users!.Update(user!);

//                 await SaveChanges();
//                 return user;
//             }
//             return default;
//         }

//         return default;
//     }


//     // public async Task<User?> DeleteUser(string email)
//     // {
//     //   User? u = await GetUser(email, null);
//     //   if (u == null)
//     //     return default;

//     //   u!.UserInfo!.Enabled = false;
//     //   _context.Users.Update(u);
//     //   await SaveChanges();

//     //   return await GetUser(email, null);
//     // }

//     public async Task<User?> GetUser(string? email, byte[]? userId)
//     {
//         User? result;
//         if (userId != null)
//             result = await MainContext.Users!.FindAsync(userId);
//         else
//             result = await MainContext.Users!.FirstOrDefaultAsync(x => x.Email == email);

//         return result == null ? default : result;
//     }


//     public Task SaveChanges()
//     {
//         return MainContext.SaveChangesAsync();
//     }

//     Task<User?> IUserDbContext.CreateUser(User user)
//     {
//         throw new NotImplementedException();
//     }

//     Task<User?> IUserDbContext.DeleteUser(string email)
//     {
//         throw new NotImplementedException();
//     }

//     Task<User?> IUserDbContext.EditEmail(User user, string newEmail)
//     {
//         throw new NotImplementedException();
//     }

//     Task<int> IUserDbContext.SaveChangesAsync(CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }
// }

