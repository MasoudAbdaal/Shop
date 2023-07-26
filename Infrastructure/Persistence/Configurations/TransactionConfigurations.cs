using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(p => p.ID);

        builder.Property(c => c.UserID).IsRequired().UserIDProperties();
        builder.Property(c => c.ID).IsRequired().HasColumnName("id");
        builder.Property(c => c.OrderID).IsRequired().HasColumnName("order_id").HasMaxLength(32);
        builder.Property(c => c.PaymentTypeID).IsRequired().HasColumnName("payment_type_id");
        builder.Property(c => c.Date).IsRequired().HasColumnName("date");
        builder.Property(c => c.IsSuccess).IsRequired().HasColumnName("is_success");
        builder.Property(c => c.StatusDescription).HasColumnName("description").HasMaxLength(40);

    }
}