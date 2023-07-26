using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Entities.Order.OrderStatus;


namespace Infrastructure.Persistence.Configurations.OrderConfs;

public class OrderStatusConfigurations : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.HasKey(o => o.ID);

        builder.HasData(Enum.GetValues(typeof(StatusTypes))
            .Cast<StatusTypes>()
            .Select(x => new OrderStatus() { ID = x, Status = x.ToString() }));

        builder.Property(o => o.ID).IsRequired().HasColumnName("id");
        builder.Property(o => o.Status).HasColumnName("status");

        builder.HasMany(o => o.Orders).WithOne(x => x.OrderStatus);
    }
}