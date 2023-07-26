using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.User;
using static Domain.Entities.User.Role;

namespace Infrastructure.Persistence.Configurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.ID);

        builder.HasData(
         Enum.GetValues(typeof(UserRoles))
           .Cast<UserRoles>().Select(u => new Role()
           {
               ID = u,
               Name = u.ToString(),
           }));

        builder.Property(r => r.ID).HasColumnName("id");
        builder.Property(r => r.Name).HasColumnName("name").HasMaxLength(50);
        
        builder.HasMany(u => u.Users).WithOne(r => r.Role).HasForeignKey(u => u.UserRoleID);
    }
}