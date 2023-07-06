using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Entities.Auth.VerificationMethod;

namespace Infrastructure.Persistence.Configurations;

public class VerificationMethodConfigurations : IEntityTypeConfiguration<VerificationMethod>
{
    public void Configure(EntityTypeBuilder<VerificationMethod> builder)
    {
        builder.HasData(
        Enum.GetValues(typeof(VerifyMethods))
        .Cast<VerifyMethods>().Select(u => new VerificationMethod()
        {
            ID = u,
            Name = u.ToString()
        }));
    }
}
