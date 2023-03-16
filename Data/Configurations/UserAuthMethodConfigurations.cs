using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Models;

namespace Shop.RepoConfigurations
{
  public class UserAuthMethodConfigurations : IEntityTypeConfiguration<UserAuthMethod>
  {
    public void Configure(EntityTypeBuilder<UserAuthMethod> builder)
    {
      builder.HasKey(x => new { x.UserID, x.AuthProviderID });
    }
  }
}