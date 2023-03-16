using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Models;

namespace Shop.RepoConfigurations
{
  public class UserAddressConfigurations : IEntityTypeConfiguration<UserAddress>
  {
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
      builder.HasKey(x => new { x.UserID, x.AddressID });
    }
  }

}