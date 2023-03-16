using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Models;
using static Shop.Models.VerificationMethod;

namespace Shop.RepoConfigurations
{
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
}
