using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class RoleImplement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleid = table.Column<byte>(name: "role_id", type: "tinyint", nullable: false),
                    rolename = table.Column<string>(name: "role_name", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<byte[]>(name: "user_id", type: "Binary(16)", maxLength: 16, nullable: false),
                    username = table.Column<string>(name: "user_name", type: "nvarchar(40)", maxLength: 40, nullable: false),
                    useremail = table.Column<string>(name: "user_email", type: "nvarchar(40)", maxLength: 40, nullable: false),
                    isemailverified = table.Column<bool>(name: "is_email_verified", type: "bit", nullable: false),
                    userpassword = table.Column<byte[]>(name: "user_password", type: "Binary(64)", maxLength: 64, nullable: false),
                    userpasswordsalt = table.Column<byte[]>(name: "user_password_salt", type: "Binary(128)", maxLength: 128, nullable: false),
                    accountenabled = table.Column<bool>(name: "account_enabled", type: "bit", nullable: false),
                    failedloginattemptscount = table.Column<byte>(name: "failed_login_attempts_count", type: "tinyint", nullable: false),
                    authenticationproviders = table.Column<int>(name: "authentication_providers", type: "int", nullable: false),
                    userrole = table.Column<byte>(name: "user_role", type: "tinyint", nullable: false),
                    twostepsverificationmethods = table.Column<int>(name: "two_steps_verification_methods", type: "int", nullable: false),
                    isphoneverified = table.Column<bool>(name: "is_phone_verified", type: "bit", nullable: false),
                    usercreatedate = table.Column<DateTime>(name: "user_createdate", type: "datetime2", nullable: true),
                    userbirthdate = table.Column<DateTime>(name: "user_birthdate", type: "datetime2", nullable: true),
                    userlastname = table.Column<string>(name: "user_lastname", type: "nvarchar(40)", maxLength: 40, nullable: true),
                    verifieddate = table.Column<DateTime>(name: "verified_date", type: "datetime2", nullable: true),
                    userphone = table.Column<string>(name: "user_phone", type: "nvarchar(max)", nullable: true),
                    resetpasstoken = table.Column<string>(name: "reset_pass_token", type: "nvarchar(max)", nullable: true),
                    resetpasstokenexpiredate = table.Column<DateTime>(name: "reset_pass_token_expire_date", type: "datetime2", nullable: true),
                    sms2stepcode = table.Column<long>(name: "sms_2step_code", type: "bigint", nullable: true),
                    token2stepcode = table.Column<long>(name: "token_2step_code", type: "bigint", nullable: true),
                    email2stepcode = table.Column<long>(name: "email_2step_code", type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userid);
                    table.ForeignKey(
                        name: "FK_Users_Roles_user_role",
                        column: x => x.userrole,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_name" },
                values: new object[,]
                {
                    { (byte)0, "ADMIN" },
                    { (byte)1, "SELLER" },
                    { (byte)2, "PURCHASER" }
                });

            migrationBuilder.CreateIndex(
                name: "Index_ID",
                table: "Users",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_role",
                table: "Users",
                column: "user_role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
