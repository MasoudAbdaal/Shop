using Contracts.Constants;
using Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RegionsConfigurations : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasData(Countries.USA, Countries.IRAN);
    }
}