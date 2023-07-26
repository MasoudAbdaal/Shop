using Domain.Entities.Auth;
using Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CartConfigurations : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c => c.ID);

        builder.Property(c => c.ID).HasColumnName("id");
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(30);
        builder.Property(c => c.UserID).UserIDProperties();

        builder.HasMany(x => x.CartItems).WithOne(x=>x.Cart);
    }
}