using Microsoft.EntityFrameworkCore;
using Shop.Models;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(_configuration.GetValue<string>("Database:ConnectionString"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<byte>();
      modelBuilder.Entity<Role>().Property(r => r.ID).HasConversion<byte>();

      modelBuilder.Entity<Role>().HasData(
        Enum.GetValues(typeof(UserRoles))
        .Cast<UserRoles>().Select(u => new Role()
        {
          ID = u,
          Name = u.ToString()
        }));

    }
  }
}