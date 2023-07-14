using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.User;

namespace Infrastructure.Persistence.Configurations;

public class UserVerificationMethodConfigurations : IEntityTypeConfiguration<UserVerificationMethod>
{
    public void Configure(EntityTypeBuilder<UserVerificationMethod> builder)
    {
        builder.HasKey(x => new { x.UserID, x.VerificationMethodID });

        builder.Property(c => c.UserID).UserIDProperties();
        builder.Property(c => c.VerificationMethodID).HasColumnName("verify_method_id");

        
    }
}