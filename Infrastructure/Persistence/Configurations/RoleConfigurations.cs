using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Entities.Auth.Role;

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