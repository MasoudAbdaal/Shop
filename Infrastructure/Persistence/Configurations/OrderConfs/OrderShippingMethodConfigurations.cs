using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Entities.Order.OrderShippingMethod;

namespace Infrastructure.Persistence.Configurations.OrderConfs;

public class OrderShippingMethodConfigurations : IEntityTypeConfiguration<OrderShippingMethod>
{
    public void Configure(EntityTypeBuilder<OrderShippingMethod> builder)
    {
        builder.HasKey(s => s.ID);

        builder.HasData(Enum.GetValues(typeof(ShippingMethods))
            .Cast<ShippingMethods>()
            .Select(x => new OrderShippingMethod() { ID = x, Name = x.ToString(), Price = 10 }));

        builder.Property(s => s.ID).HasColumnName("id");
        builder.Property(s => s.Name).HasColumnName("name");
        builder.Property(s => s.Price).HasColumnName("price").HasColumnType("Money");

        builder.HasMany(x => x.Orders).WithOne(x => x.OrderShippingMethod);
    }
}