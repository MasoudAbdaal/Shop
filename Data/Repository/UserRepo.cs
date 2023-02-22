using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Data.Interface;
using Shop.Models;

namespace Shop.Data
{

	public class UserRepo : IUserRepo
	{
		private readonly MainContext _context;

		public UserRepo(MainContext context)
		{
			_context = context;
		}

		public Task SaveChanges()
		{
			return _context.SaveChangesAsync();
		}

		public async Task<User?> CreateUser(User user)
		{
			User? u = await GetUser(user.Email, null);

			if (u == null)
			{
				await _context.Users.AddAsync(user!);
				await SaveChanges();
				return await _context.Users.FindAsync(user?.ID);
			}

			return u;
		}


		public async Task<User?> GetUser(string? email, byte[]? userId)
		{
			User? result;
			if (userId != null)
				result = await _context.Users.FindAsync(userId);
			else
				result = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

			return result == null ? default : result;
		}

		public async Task<User?> EditUser(User user)
		{
			User? result;
			if (user.Email != null)
				result = await GetUser(user.Email, null);
			else
				result = await GetUser(null, user.ID);



			if (result != null)
			{
				User? J = new User() { Name = "NEW USSSSSSSSSSSSER" };

				foreach (PropertyInfo item in user.GetType().GetProperties())
				{
					if (item.GetValue(user, null) != null)
					{

						Console.WriteLine("{0} ==>{1}", item.Name, item.GetValue(user, null) == null ? "NULL" : item.GetValue(user, null));

						Console.WriteLine("{0}--------------{1}", J.GetType().GetProperty(item.Name)!.Name,
						J.GetType().GetProperty(item.Name)!.GetValue(user, null)!);

					}

				}

				_context.Users.Update(result!);
				await SaveChanges();
				return await GetUser(null, result.ID);
			}

			return default;
		}

		public async Task<User?> DeleteUser(string email)
		{
			User? u = await GetUser(email, null);
			if (u == null)
				return default;

			u!.UserInfo!.Enabled = false;
			_context.Users.Update(u);
			await SaveChanges();

			return await GetUser(email, null);
		}
	}

}
