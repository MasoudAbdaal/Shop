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
        builder.HasKey(u => u.ID);


        builder.Property(u => u.ID).IsRequired().HasColumnName("id").HasColumnType("Binary").IsConcurrencyToken().HasMaxLength(16).ValueGeneratedNever();
        builder.Property(u => u.Name).IsRequired().HasColumnName("name").HasMaxLength(40);
        builder.Property(u => u.Email).IsRequired().HasColumnName("email").HasMaxLength(40);
        builder.Property(u => u.Password).IsRequired().HasColumnName("password").HasMaxLength(64).HasColumnType("Binary");
        builder.Property(u => u.PasswordSalt).IsRequired().HasColumnName("password_salt").HasMaxLength(128).HasColumnType("Binary");
        builder.Property(u => u.ResetPasswordToken).HasColumnName("reset_pass_token").HasMaxLength(128).HasColumnType("Binary");
        builder.Property(u => u.Role).HasColumnName("role");
        builder.Property(u => u.ResetPasswordTokenExpires).HasColumnName("reset_pass_token_expire_date");
        builder.Property(u => u.SMS_Code).HasColumnName("sms_2step_code");
        builder.Property(u => u.Token_Code).HasColumnName("token_2step_code");
        builder.Property(u => u.Email_Code).HasColumnName("email_2step_code");

        builder.HasOne(u => u.UserInfo).WithOne().HasForeignKey<UserInfo>(ui => ui.ID);
        

        builder.HasMany(u => u.UserAuthMethods).WithOne().HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);
        builder.HasMany(u => u.UserAddress).WithOne().HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);
        builder.HasMany(u => u.Cart).WithOne().HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);
        builder.HasMany(u => u.Payment).WithOne().HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);
        builder.HasMany(u => u.UserReview).WithOne().HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);
        builder.HasMany(u => u.Order).WithOne().HasPrincipalKey(u => u.ID).HasForeignKey(x => x.User_ID);
        builder.HasMany(u => u.UserVerificationMethods).WithOne().HasPrincipalKey(u => u.ID).HasForeignKey(x => x.UserID);
    }
}