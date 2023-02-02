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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(_configuration.GetValue<string>("Database:ConnectionString"));
    }


    public DbSet<User> Users => Set<User>();
  }
}