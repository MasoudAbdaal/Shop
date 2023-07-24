using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.PromotionConfs;

public class PromotionCategoriesConfigurations : IEntityTypeConfiguration<PromotionCategories>
{
    public void Configure(EntityTypeBuilder<PromotionCategories> builder)
    {
        builder.HasKey(x => new { x.CategoryID, x.PromotionID });


        builder.Property(c => c.PromotionID).HasColumnName("promotion_id");
        builder.Property(c => c.CategoryID).HasColumnName("category_id");
    }
}