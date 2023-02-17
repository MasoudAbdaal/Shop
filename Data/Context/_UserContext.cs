using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Shop.Constants;
using Shop.Models;
using static Shop.Models.AuthProvider;
using static Shop.Models.Role;
using static Shop.Models.VerificationMethod;

namespace Shop.Data
{
  public class _UserContext : DbContext
  {
    private readonly IConfiguration _configuration;
    private readonly DbContextOptions<_UserContext> _options;

    public _UserContext(DbContextOptions<_UserContext> options, IConfiguration configuration) : base(options)
    {
      _configuration = configuration;
      _options = options;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(_configuration.GetValue<string>("Database:ConnectionString")
      , x => x.UseNetTopologySuite()
      );
    }

  }
}