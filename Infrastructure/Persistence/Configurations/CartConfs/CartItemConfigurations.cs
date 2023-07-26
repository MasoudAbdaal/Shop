
using Domain.Entities.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CartItemConfigurations : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(c => c.ID);

        builder.Property(c => c.ID).HasColumnName("id").IsRequired();
        builder.Property(c => c.CartID).HasColumnName("cart_id").HasMaxLength(30);
        builder.Property(c => c.ProductItemID).HasColumnName("product_item_id");
        builder.Property(c => c.Quantity).HasColumnName("quantity");

    }
}