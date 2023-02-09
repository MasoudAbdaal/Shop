using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Shop.Constants;
using Shop.Models;
using static Shop.Models.AuthProvider;
using static Shop.Models.Role;
using static Shop.Models.VerificationMethod;

namespace Shop.Data
{
  public class UserContext : DbContext
  {
    private readonly IConfiguration _configuration;
    private readonly DbContextOptions<UserContext> _options;

    public UserContext(DbContextOptions<UserContext> options, IConfiguration configuration) : base(options)
    {
      _configuration = configuration;
      _options = options;
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserAuthMethod> UserAuthMethods => Set<UserAuthMethod>();
    public DbSet<AuthProvider> AuthProviders => Set<AuthProvider>();
    public DbSet<UserVerificationMethod> UserVerificationMethods => Set<UserVerificationMethod>();
    public DbSet<VerificationMethod> VerificationMethods => Set<VerificationMethod>();
    public DbSet<UserInfo> UserInfo => Set<UserInfo>();
    public DbSet<UserAddress> UserAddress => Set<UserAddress>();
    public DbSet<Address> Address => Set<Address>();
    public DbSet<Region> Region => Set<Region>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(_configuration.GetValue<string>("Database:ConnectionString")
      , x => x.UseNetTopologySuite()
      );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserAuthMethod>().HasKey(x => new { x.UserID, x.AuthProviderID });
      modelBuilder.Entity<UserVerificationMethod>().HasKey(x => new { x.UserID, x.VerificationMethodID });
      modelBuilder.Entity<UserAddress>().HasKey(x => new { x.UserID, x.AddressID });


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

      modelBuilder.Entity<VerificationMethod>().HasData(
        Enum.GetValues(typeof(VerifyMethods))
        .Cast<VerifyMethods>().Select(u => new VerificationMethod()
        {
          ID = u,
          Name = u.ToString()
        }));
    }
  }
}