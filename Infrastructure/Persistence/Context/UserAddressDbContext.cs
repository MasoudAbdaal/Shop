using Domain.Entities.User;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;
internal sealed class UserAddressDbContext : ModuleDbContext, IUserAddressDbContext
{
    public DbSet<UserAddress>? UserAddresses { get; set; }
    protected override string Schema => "Shop";

    public UserAddressDbContext(DbContextOptions<UserAddressDbContext> options) : base(options)
    {
        UserAddresses = Set<UserAddress>();
    }


}