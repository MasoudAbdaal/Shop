using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Auth;
using static Domain.Entities.Auth.AuthProvider;

namespace Infrastructure.Persistence.Configurations;

public class AuthProviderConfigurations : IEntityTypeConfiguration<AuthProvider>
{
    public void Configure(EntityTypeBuilder<AuthProvider> builder)
    {
        builder.HasKey(a => a.ID);

        builder.HasData(
          Enum.GetValues(typeof(Providers))
          .Cast<Providers>().Select(u => new AuthProvider()
          {
              ID = u,
              Name = u.ToString()
          }));

        builder.Property(x => x.ID).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(40);

        builder.HasMany(x => x.UserAuthMethods).WithOne(x => x.AuthProvider).HasForeignKey(ua => ua.AuthProviderID);
    }
}