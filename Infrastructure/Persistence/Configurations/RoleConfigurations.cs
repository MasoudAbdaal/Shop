using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Entities.User.Role;

namespace Infrastructure.Persistence.Configurations;

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
           
        builder.HasKey(r => r.ID);
        builder.HasMany(x => x.Users).WithOne().HasForeignKey(u => u.Role).OnDelete(DeleteBehavior.Cascade);
    }
}