using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserAddressConfigurations : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(x => new { x.UserID, x.AddressID });

        builder.Property(u => u.UserID).IsRequired().HasColumnName("user_id").HasColumnType("Binary").HasMaxLength(16);
        builder.Property(u => u.UserID).IsRequired().HasColumnName("address_id").HasColumnType("Binary").HasMaxLength(4);
    }
}