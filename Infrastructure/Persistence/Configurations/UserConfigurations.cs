using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.User;
using static Domain.Entities.User.Role;
using Domain.Entities.Auth;
using Microsoft.VisualBasic;

namespace Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.ID).IsUnique();

        builder.Property(u => u.ID).IsRequired().HasColumnName("id").HasColumnType("Binary").IsConcurrencyToken().HasMaxLength(16).ValueGeneratedNever();
        builder.Property(u => u.Name).IsRequired().HasColumnName("name").HasMaxLength(40);
        builder.Property(u => u.Email).IsRequired().HasColumnName("email").HasMaxLength(40);
        builder.Property(u => u.Password).IsRequired().HasColumnName("password").HasMaxLength(64).HasColumnType("Binary");
        builder.Property(u => u.PasswordSalt).IsRequired().HasColumnName("password_salt").HasMaxLength(128).HasColumnType("Binary");
        builder.Property(u => u.ResetPasswordToken).HasColumnName("reset_pass_token").HasMaxLength(128).HasColumnType("Binary");
        builder.Property(u => u.UserRoleID).HasColumnName("role_id");
        builder.Property(u => u.ResetPasswordTokenExpires).HasColumnName("reset_pass_token_expire_date");
        builder.Property(u => u.SMS_Code).HasColumnName("sms_2step_code");
        builder.Property(u => u.Token_Code).HasColumnName("token_2step_code");
        builder.Property(u => u.Email_Code).HasColumnName("email_2step_code");

        builder.HasOne(ui => ui.UserInfo).WithOne(u => u.User).HasForeignKey<UserInfo>(ui => ui.UserID);

        builder.HasMany(u => u.UserAuthMethods).WithOne(u => u.User);
        builder.HasMany(u => u.UserVerificationMethods).WithOne(u => u.User).HasForeignKey(x => x.UserID);
        builder.HasMany(u => u.UserAddress).WithOne(u => u.User).HasForeignKey(ua => ua.UserID);
        builder.HasMany(u => u.Carts).WithOne(u => u.User).HasForeignKey(ua => ua.UserID);
        builder.HasMany(u => u.Payments).WithOne(u => u.User).HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);

        builder.HasMany(u => u.UserReviews).WithOne(u => u.User).HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);
        builder.HasMany(u => u.Orders).WithOne(u => u.User).HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);
    }
}