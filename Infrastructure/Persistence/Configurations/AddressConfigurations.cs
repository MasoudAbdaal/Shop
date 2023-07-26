using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Address;

namespace Infrastructure.Persistence.Configurations;

public class AddressConfigurations : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.ID);

        builder.Property(a => a.ID).IsRequired().HasColumnName("id").HasMaxLength(4).ValueGeneratedNever();
        builder.Property(a => a.RegionID).HasColumnName("region_id");
        builder.Property(a => a.PostalCode).HasColumnName("postal_code").HasMaxLength(20);
        builder.Property(a => a.UnitNumber).HasColumnName("unit_number");
        builder.Property(a => a.AddressLine).HasColumnName("address_line").HasMaxLength(100);
        builder.Property(a => a.Location).HasColumnName("location");
        builder.Property(a => a.LocationAddress).HasColumnName("location_address").HasMaxLength(100);

        builder.HasMany(ua => ua.UserAddresses).WithOne(a => a.Address);
        builder.HasMany(ua => ua.Orders).WithOne(a => a.Address);
    }
}