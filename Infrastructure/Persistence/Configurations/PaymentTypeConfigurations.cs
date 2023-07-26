using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PaymentTypeConfigurations : IEntityTypeConfiguration<PaymentType>
{
    public void Configure(EntityTypeBuilder<PaymentType> builder)
    {
        builder.HasKey(p => p.ID);

        builder.HasData(
            new PaymentType { ID = 1, Name = "Cash" },
            new PaymentType { ID = 2, Name = "Credit Card" },
            new PaymentType { ID = 3, Name = "PayPal" }
            );

        builder.Property(p => p.ID).HasColumnName("id");
        builder.Property(p => p.Name).HasColumnName("payment_type_name").HasMaxLength(20);

        builder.HasMany(x => x.Transactions).WithOne(p => p.PaymentType);
    }
}