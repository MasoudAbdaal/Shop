using Microsoft.EntityFrameworkCore;
using Shop.Models;
using static Shop.Models.AuthProvider;
using static Shop.Models.Role;
using static Shop.Models.VerificationMethod;

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
    public DbSet<UserVerificationMethod> UserVerificationMethods => Set<UserVerificationMethod>();
    public DbSet<VerificationMethod> VerificationMethods => Set<VerificationMethod>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(_configuration.GetValue<string>("Database:ConnectionString"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserAuthMethod>().HasKey(x => new { x.UserID, x.AuthProviderID });
      modelBuilder.Entity<UserVerificationMethod>().HasKey(x => new { x.UserID, x.VerificationMethodID });


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