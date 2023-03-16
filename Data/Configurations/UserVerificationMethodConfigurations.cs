using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Models;

namespace Shop.RepoConfigurations
{
  public class UserVerificationMethodConfigurations : IEntityTypeConfiguration<UserVerificationMethod>
  {
    public void Configure(EntityTypeBuilder<UserVerificationMethod> builder)
    {
      builder.HasKey(x => new { x.UserID, x.VerificationMethodID });
    }
  }
}