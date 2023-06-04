using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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