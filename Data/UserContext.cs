using Microsoft.EntityFrameworkCore;
using Shop.Models;
using static Shop.Models.AuthProvider;
using static Shop.Models.Role;

namespace Shop.Data
{
  public class UserContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public UserContext(DbContextOptions<UserContext> options, IConfiguration configuration) : base(options)
    {
      _configuration = configuration;
    }
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserAuthMethod> UserAuthMethods => Set<UserAuthMethod>();
    public DbSet<AuthProvider> AuthProviders => Set<AuthProvider>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(_configuration.GetValue<string>("Database:ConnectionString"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<byte>();
      modelBuilder.Entity<Role>().Property(r => r.ID).HasConversion<byte>();
      modelBuilder.Entity<UserAuthMethod>().HasKey(x => new { x.UserID, x.AuthProviderID });
      

      modelBuilder.Entity<Role>().HasData(
        Enum.GetValues(typeof(UserRoles))
        .Cast<UserRoles>().Select(u => new Role()
        {
          ID = u,
          Name = u.ToString()
        }));


      modelBuilder.Entity<AuthProvider>().HasData(
        Enum.GetValues(typeof(Providers))
        .Cast<Providers>().Select(u => new AuthProvider()
        {
          ID = u,
          Name = u.ToString()
        }));


    }
  }
}