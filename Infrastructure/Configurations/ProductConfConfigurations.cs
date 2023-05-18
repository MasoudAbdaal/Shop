using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.RepoConfigurations
{
    public class ProductConfConfigurations : IEntityTypeConfiguration<ProductConf>
  {
    public void Configure(EntityTypeBuilder<ProductConf> builder)
    {
      builder.HasKey(x => new { x.ProductItemID, x.VariationOptionID });
    }
  }
}