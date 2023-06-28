using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserInfoConfigurations : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.HasKey(ui => ui.ID);

        builder.Property(ui => ui.ID).IsRequired().HasColumnName("user_id").HasColumnType("Binary").HasMaxLength(16);

        builder.HasOne(ui => ui.User).WithOne(ui => ui.UserInfo).HasForeignKey<UserInfo>(x => x.ID).HasPrincipalKey<User>(u => u.ID);
    }
}