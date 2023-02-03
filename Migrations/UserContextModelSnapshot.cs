﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Data;

#nullable disable

namespace Shop.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.Models.AuthProvider", b =>
                {
                    b.Property<byte>("ID")
                        .HasColumnType("tinyint")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.HasKey("ID");

                    b.ToTable("AuthProviders");

                    b.HasData(
                        new
                        {
                            ID = (byte)0,
                            Name = "EMAIL"
                        },
                        new
                        {
                            ID = (byte)1,
                            Name = "GOOGLE"
                        },
                        new
                        {
                            ID = (byte)2,
                            Name = "FACEBOOK"
                        },
                        new
                        {
                            ID = (byte)3,
                            Name = "MICROSOFT"
                        });
                });

            modelBuilder.Entity("Shop.Models.Role", b =>
                {
                    b.Property<byte>("ID")
                        .HasColumnType("tinyint")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = (byte)0,
                            Name = "ADMIN"
                        },
                        new
                        {
                            ID = (byte)1,
                            Name = "SELLER"
                        },
                        new
                        {
                            ID = (byte)2,
                            Name = "PURCHASER"
                        });
                });

            modelBuilder.Entity("Shop.Models.User", b =>
                {
                    b.Property<byte[]>("ID")
                        .IsConcurrencyToken()
                        .HasMaxLength(16)
                        .HasColumnType("Binary")
                        .HasColumnName("id");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("email");

                    b.Property<long?>("Email_Code")
                        .HasColumnType("bigint")
                        .HasColumnName("email_2step_code");

                    b.Property<bool>("Email_Verified")
                        .HasColumnType("bit")
                        .HasColumnName("is_email_verified");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit")
                        .HasColumnName("account_enabled");

                    b.Property<byte>("FailedLoginAttempts")
                        .HasColumnType("tinyint")
                        .HasColumnName("failed_login_attempts_count");

                    b.Property<string>("LastName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("Binary")
                        .HasColumnName("password");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("Binary")
                        .HasColumnName("password_salt");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("phone");

                    b.Property<bool>("PhoneNumber_Verified")
                        .HasColumnType("bit")
                        .HasColumnName("is_phone_verified");

                    b.Property<string>("ResetPasswordToken")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("reset_pass_token");

                    b.Property<DateTime?>("ResetPasswordTokenExpires")
                        .HasColumnType("datetime2")
                        .HasColumnName("reset_pass_token_expire_date");

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint")
                        .HasColumnName("role");

                    b.Property<long?>("SMS_Code")
                        .HasColumnType("bigint")
                        .HasColumnName("sms_2step_code");

                    b.Property<long?>("Token_Code")
                        .HasColumnType("bigint")
                        .HasColumnName("token_2step_code");

                    b.Property<int>("TwoStepMethod")
                        .HasColumnType("int")
                        .HasColumnName("two_steps_verification_methods");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("verified_date");

                    b.HasKey("ID");

                    b.HasIndex("Role");

                    b.HasIndex(new[] { "ID" }, "Index_ID")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Shop.Models.UserAuthMethod", b =>
                {
                    b.Property<byte[]>("UserID")
                        .HasMaxLength(16)
                        .HasColumnType("Binary")
                        .HasColumnName("user_id");

                    b.Property<byte>("AuthProviderID")
                        .HasColumnType("tinyint")
                        .HasColumnName("auth_provider_id");

                    b.HasKey("UserID", "AuthProviderID");

                    b.HasIndex("AuthProviderID");

                    b.ToTable("UserAuthMethods");
                });

            modelBuilder.Entity("Shop.Models.User", b =>
                {
                    b.HasOne("Shop.Models.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Shop.Models.UserAuthMethod", b =>
                {
                    b.HasOne("Shop.Models.AuthProvider", "AuthProvider")
                        .WithMany("UserAuthMethod")
                        .HasForeignKey("AuthProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Models.User", "Users")
                        .WithMany("UserAuthMethods")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthProvider");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Shop.Models.AuthProvider", b =>
                {
                    b.Navigation("UserAuthMethod");
                });

            modelBuilder.Entity("Shop.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Shop.Models.User", b =>
                {
                    b.Navigation("UserAuthMethods");
                });
#pragma warning restore 612, 618
        }
    }
}
