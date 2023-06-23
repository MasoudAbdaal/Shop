using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Entities.Auth.AuthProvider;
namespace Infrastructure.Persistence.Configurations;

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