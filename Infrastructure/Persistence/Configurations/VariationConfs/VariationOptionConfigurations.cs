using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Product;

namespace Infrastructure.Persistence.Configurations.VariationConfs;

public class VariationOptionsConfigurations : IEntityTypeConfiguration<VariationOption>
{
    public void Configure(EntityTypeBuilder<VariationOption> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ID).HasColumnName("id").IsRequired();
        builder.Property(x => x.VariationID).HasColumnName("variation_id");
        builder.Property(x => x.Value).HasColumnName("value").HasMaxLength(20);

        builder.HasMany(x => x.ProductConfs).WithOne();
    }
}
