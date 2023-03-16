using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Models;
using static Shop.Models.Role;

namespace Shop.RepoConfigurations
{
  public class RoleConfigurations : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.HasData(
       Enum.GetValues(typeof(UserRoles))
         .Cast<UserRoles>().Select(u => new Role()
         {
           ID = u,
           Name = u.ToString(),
         }));
    }
  }
}