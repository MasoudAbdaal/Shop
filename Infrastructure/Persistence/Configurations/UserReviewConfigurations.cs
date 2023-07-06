using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserReviewConfigurations : IEntityTypeConfiguration<UserReview>
{
    public void Configure(EntityTypeBuilder<UserReview> builder)
    {
        builder.HasKey(ur => ur.ID);

        builder.Property(ur => ur.ID).IsRequired().HasColumnName("id");
        builder.Property(ur => ur.UserID).HasColumnName("user_id").HasColumnType("Binary").HasMaxLength(16);
        builder.Property(ur => ur.OrderLineID).HasColumnName("order_line_id").HasColumnType("Binary").HasMaxLength(32).IsConcurrencyToken();
        builder.Property(ur => ur.Rate).HasColumnName("rate").HasMaxLength(5);
        builder.Property(ur => ur.Comment).HasColumnName("comment").HasMaxLength(512);
    }
}