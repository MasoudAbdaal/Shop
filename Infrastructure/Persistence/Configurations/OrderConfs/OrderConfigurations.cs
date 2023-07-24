using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.OrderConfs;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.ID);

        builder.Property(o => o.ID).HasColumnName("id").HasColumnType("Binary").IsConcurrencyToken().HasMaxLength(32);
        builder.Property(o => o.UserID).UserIDProperties();
        builder.Property(o => o.TransactionID).HasColumnName("transaction_id").IsRequired();
        builder.Property(o => o.OrderStatusID).HasColumnName("order_status_id").IsRequired();
        builder.Property(o => o.OrderShippingMethodID).HasColumnName("order_shipping_method_id").IsRequired();
        builder.Property(o => o.AddressID).HasColumnName("shipping_address_id").IsRequired();
        builder.Property(o => o.Date).HasColumnName("ordered_date");
        builder.Property(o => o.Total).HasColumnName("order_total").HasColumnType("Money");

        builder.HasMany(o => o.OrderLines).WithOne(o => o.Order);
        builder.HasMany(o => o.Transactions).WithOne(o => o.Order);
    }
}
