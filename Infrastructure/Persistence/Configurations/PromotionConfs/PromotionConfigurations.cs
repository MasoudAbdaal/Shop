using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Product;

namespace Infrastructure.Persistence.Configurations.PromotionConfs;

public class PromotionConfigurations : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.HasKey(c => c.ID);

        builder.Property(x => x.ID).HasColumnName("id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(20);
        builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(64);
        builder.Property(x => x.DiscountRate).HasColumnName("rate").IsRequired();
        builder.Property(x => x.DiscountStartDate).HasColumnName("start_date").IsRequired();
        builder.Property(x => x.DiscountEndDate).HasColumnName("end_date").IsRequired();

        builder.HasMany(x => x.PromotionCategories).WithOne(x=>x.Promotion);
        builder.HasMany(x => x.PromotionProducts).WithOne(x=>x.Promotion);
    }
}