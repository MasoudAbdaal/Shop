using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

public interface IUserAddressDbContext
{
    DbSet<UserAddress>? UserAddresses { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}