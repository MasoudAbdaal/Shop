using Domain.Entities.Auth;
using Domain.Entities.Cart;
using Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.ID);
                
        builder.Property(c => c.ID).HasColumnName("id");
        builder.Property(c => c.UserID).UserIDProperties();
        builder.Property(c => c.PaymentTypeID).HasColumnName("payment_type_id");


    }
}