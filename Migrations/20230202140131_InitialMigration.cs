using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<byte[]>(name: "user_id", type: "Binary(16)", maxLength: 16, nullable: false),
                    username = table.Column<string>(name: "user_name", type: "nvarchar(40)", maxLength: 40, nullable: false),
                    useremail = table.Column<string>(name: "user_email", type: "nvarchar(40)", maxLength: 40, nullable: false),
                    userlastname = table.Column<string>(name: "user_lastname", type: "nvarchar(40)", maxLength: 40, nullable: true),
                    usercreatedate = table.Column<DateTime>(name: "user_createdate", type: "datetime2", nullable: true),
                    userbirthdate = table.Column<DateTime>(name: "user_birthdate", type: "datetime2", nullable: true),
                    verifieddate = table.Column<DateTime>(name: "verified_date", type: "datetime2", nullable: true),
                    isemailverified = table.Column<bool>(name: "is_email_verified", type: "bit", nullable: false),
                    userpassword = table.Column<byte[]>(name: "user_password", type: "Binary(64)", maxLength: 64, nullable: false),
                    userpasswordsalt = table.Column<byte[]>(name: "user_password_salt", type: "Binary(128)", maxLength: 128, nullable: false),
                    accountenabled = table.Column<bool>(name: "account_enabled", type: "bit", nullable: false),
                    userphone = table.Column<string>(name: "user_phone", type: "nvarchar(max)", nullable: true),
                    isphoneverified = table.Column<bool>(name: "is_phone_verified", type: "bit", nullable: false),
                    resetpasstoken = table.Column<string>(name: "reset_pass_token", type: "nvarchar(max)", nullable: true),
                    resetpasstokenexpiredate = table.Column<DateTime>(name: "reset_pass_token_expire_date", type: "datetime2", nullable: true),
                    sms2stepcode = table.Column<long>(name: "sms_2step_code", type: "bigint", nullable: true),
                    token2stepcode = table.Column<long>(name: "token_2step_code", type: "bigint", nullable: true),
                    email2stepcode = table.Column<long>(name: "email_2step_code", type: "bigint", nullable: true),
                    failedloginattemptscount = table.Column<byte>(name: "failed_login_attempts_count", type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userid);
                });

            migrationBuilder.CreateIndex(
                name: "Index_ID",
                table: "Users",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
