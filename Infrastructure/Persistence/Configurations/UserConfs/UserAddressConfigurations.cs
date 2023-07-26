using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.UserConfs;

public class UserAddressConfigurations : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(x => new { x.UserID, x.AddressID });

        builder.Property(u => u.UserID).IsRequired().UserIDProperties();
        builder.Property(u => u.AddressID).IsRequired().HasColumnName("address_id").HasMaxLength(4).ValueGeneratedNever();
    }
}