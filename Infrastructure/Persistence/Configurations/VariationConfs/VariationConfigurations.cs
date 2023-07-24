using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Product;
using static Domain.Entities.Product.Variation;

namespace Infrastructure.Persistence.Configurations.VariationConfs;

public class VariationConfigurations : IEntityTypeConfiguration<Variation>
{
    public void Configure(EntityTypeBuilder<Variation> builder)
    {
        builder.HasKey(x => x.ID);

        builder.HasData(Enum.GetValues(typeof(Variations)).Cast<Variations>().Select(x => new Variation() { ID = x, Name = x.ToString() }));

        builder.Property(x => x.ID).HasColumnName("id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(20);
        builder.Property(x => x.CategoryID).HasColumnName("category_id");

        builder.HasMany(x=>x.VariationOptions).WithOne();
    }
}
