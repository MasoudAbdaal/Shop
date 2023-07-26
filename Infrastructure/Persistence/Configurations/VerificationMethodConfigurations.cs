using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Auth;
using static Domain.Entities.Auth.VerificationMethod;

namespace Infrastructure.Persistence.Configurations;

public class VerificationMethodConfigurations : IEntityTypeConfiguration<VerificationMethod>
{
    public void Configure(EntityTypeBuilder<VerificationMethod> builder)
    {
        builder.HasKey(x => x.ID);

        builder.HasData(
        Enum.GetValues(typeof(VerifyMethods))
        .Cast<VerifyMethods>().Select(u => new VerificationMethod()
        {
            ID = u,
            Name = u.ToString()
        }));

        builder.Property(x => x.ID).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(40);

        builder.HasMany(uv => uv.UserVerificationMethods).WithOne(v => v.VerificationMethod);
    }
}
