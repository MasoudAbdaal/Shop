using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserVerificationMethodConfigurations : IEntityTypeConfiguration<UserVerificationMethod>
{
    public void Configure(EntityTypeBuilder<UserVerificationMethod> builder)
    {
        builder.HasKey(x => new { x.UserID, x.VerificationMethodID });

        builder.Property(c => c.UserID).HasColumnName("user_id").HasColumnType("Binary").HasMaxLength(16);
        builder.Property(c => c.VerificationMethodID).HasColumnName("verify_method_id");
    }
}