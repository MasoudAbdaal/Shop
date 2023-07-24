using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ID).HasColumnName("id").IsRequired();
        builder.Property(x => x.ParentID).HasColumnName("parent_id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(20);

        builder.HasOne(x => x.ParentCategory).WithMany(x => x.SubCategories).HasForeignKey(x => x.ParentID).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.PromotionCategories).WithOne();
        builder.HasMany(x => x.Products).WithOne();
        builder.HasMany(x => x.Variations).WithOne();
    }
}