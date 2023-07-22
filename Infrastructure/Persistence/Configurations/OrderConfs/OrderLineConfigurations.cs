using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.OrderConfs;

public class OrderLineConfigurations : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ID).HasColumnName("id").HasColumnType("Binary").IsConcurrencyToken().HasMaxLength(32);
        builder.Property(x => x.ProductItemID).HasColumnName("product_item_id");
        builder.Property(x => x.OrderID).HasColumnName("order_id").HasColumnType("Binary").IsConcurrencyToken().HasMaxLength(32); ;
        builder.Property(x => x.Quantity).HasColumnName("quantity");
        builder.Property(x => x.Price).HasColumnName("price").HasColumnType("Money");

        builder.HasMany(x => x.UserReviews).WithOne(x => x.OrderLine).HasForeignKey(x=>x.OrderLineID);
    }
}