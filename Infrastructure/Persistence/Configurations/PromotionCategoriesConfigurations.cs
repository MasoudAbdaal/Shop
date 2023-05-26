using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.RepoConfigurations
{
    public class PromotionCategoriesConfigurations : IEntityTypeConfiguration<PromotionCategories>
  {
    public void Configure(EntityTypeBuilder<PromotionCategories> builder)
    {
      builder.HasKey(x => new { x.CategoryID, x.PromotionID });
    }
  }
}