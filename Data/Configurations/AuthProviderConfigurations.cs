using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Models;
using static Shop.Models.AuthProvider;

namespace Shop.RepoConfigurations
{
  public class AuthProviderConfigurations : IEntityTypeConfiguration<AuthProvider>
  {
    public void Configure(EntityTypeBuilder<AuthProvider> builder)
    {
      builder.HasData(
        Enum.GetValues(typeof(Providers))
        .Cast<Providers>().Select(u => new AuthProvider()
        {
          ID = u,
          Name = u.ToString()
        }));
    }
  }
}