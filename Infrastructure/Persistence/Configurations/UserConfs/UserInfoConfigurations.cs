using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.User;

namespace Infrastructure.Persistence.Configurations.UserConfs;

public class UserInfoConfigurations : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.HasKey(ui => ui.UserID);

        builder.Property(ui => ui.UserID).UserIDProperties();
        builder.Property(ui => ui.LastName).HasColumnName("lastname").HasMaxLength(40);
        builder.Property(ui => ui.PhoneNumber).HasColumnName("phone").HasMaxLength(15).IsPhone();
        builder.Property(ui => ui.PhoneNumber_Verified).HasColumnName("is_phone_verified");
        builder.Property(ui => ui.Enabled).HasColumnName("account_enabled");
        builder.Property(ui => ui.Email_Verified).HasColumnName("is_email_verified");
        builder.Property(ui => ui.VerifiedDate).HasColumnName("verified_date");
        builder.Property(ui => ui.CreateDate).HasColumnName("createdate");
        builder.Property(ui => ui.BirthDate).HasColumnName("birthdate");
        builder.Property(ui => ui.FailedLoginAttempts).HasColumnName("failed_login_attempts_count");


        builder.HasOne(ui => ui.User).WithOne(ui => ui.UserInfo).HasForeignKey<UserInfo>(x => x.UserID).HasPrincipalKey<User>(u => u.ID);
    }
}