﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Data;

#nullable disable

namespace Shop.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20230202140131_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.Models.User", b =>
                {
                    b.Property<byte[]>("ID")
                        .IsConcurrencyToken()
                        .HasMaxLength(16)
                        .HasColumnType("Binary")
                        .HasColumnName("user_id");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("user_birthdate");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("user_createdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("user_email");

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
                        .HasColumnName("user_lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("user_name");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("Binary")
                        .HasColumnName("user_password");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("Binary")
                        .HasColumnName("user_password_salt");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_phone");

                    b.Property<bool>("PhoneNumber_Verified")
                        .HasColumnType("bit")
                        .HasColumnName("is_phone_verified");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reset_pass_token");

                    b.Property<DateTime?>("ResetPasswordTokenExpires")
                        .HasColumnType("datetime2")
                        .HasColumnName("reset_pass_token_expire_date");

                    b.Property<long?>("SMS_Code")
                        .HasColumnType("bigint")
                        .HasColumnName("sms_2step_code");

                    b.Property<long?>("Token_Code")
                        .HasColumnType("bigint")
                        .HasColumnName("token_2step_code");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("verified_date");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "ID" }, "Index_ID")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
