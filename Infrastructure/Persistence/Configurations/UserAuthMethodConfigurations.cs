using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserAuthMethodConfigurations : IEntityTypeConfiguration<UserAuthMethod>
{
    public void Configure(EntityTypeBuilder<UserAuthMethod> builder)
    {
        builder.HasKey(x => new { x.UserID, x.AuthProviderID });

        builder.Property(u => u.UserID).IsRequired().UserIDProperties();
        builder.Property(u => u.AuthProviderID).IsRequired().HasColumnName("auth_provider_id");
    }
}