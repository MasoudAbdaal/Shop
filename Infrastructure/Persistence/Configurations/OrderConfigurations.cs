using Domain.Entities.Auth;
using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Entities.Auth.VerificationMethod;

namespace Infrastructure.Persistence.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.ID);

        builder.Property(o => o.ID).HasColumnName("id").HasColumnType("Binary").IsConcurrencyToken().HasMaxLength(32);
        builder.Property(o => o.UserID).UserIDProperties();
        builder.Property(o => o.TransactionID).HasColumnName("transaction_id");
        builder.Property(o => o.AddressID).HasColumnName("shipping_address");
        builder.Property(o => o.ShippingMethod).HasColumnName("shipping_method");
        builder.Property(o => o.Status).HasColumnName("status");
        builder.Property(o => o.Date).HasColumnName("ordered_date");
        builder.Property(o => o.Total).HasColumnName("order_total").HasColumnType("Money");

        builder.HasMany(o => o.Transactions).WithOne(o => o.Order).HasForeignKey(x => x.OrderID);
    }
}
