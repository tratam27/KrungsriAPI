using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Krungsri.DataAccess.Migrations
{
    public partial class create2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BookBank = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Merchant",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    MerchantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    BookBank = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchant", x => x.MerchantId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    BookBank = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AdminToken",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefreshToken = table.Column<string>(nullable: true),
                    AdminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminToken_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchantToken",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefreshToken = table.Column<string>(nullable: true),
                    MerchantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantToken_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchant",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminTransaction",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MoneyAmount = table.Column<decimal>(nullable: false),
                    Ref = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminTransaction_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminTransaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchantTransaction",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MerchantId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    MoneyAmount = table.Column<decimal>(nullable: false),
                    Ref = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantTransaction_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchant",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchantTransaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OTP",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Otp = table.Column<string>(nullable: true),
                    Ref = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OTP_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    UpdateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreateDateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefreshToken = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminToken_AdminId",
                table: "AdminToken",
                column: "AdminId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminTransaction_AdminId",
                table: "AdminTransaction",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminTransaction_UserId",
                table: "AdminTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantToken_MerchantId",
                table: "MerchantToken",
                column: "MerchantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MerchantTransaction_MerchantId",
                table: "MerchantTransaction",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantTransaction_UserId",
                table: "MerchantTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OTP_UserId",
                table: "OTP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserId",
                table: "Token",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminToken");

            migrationBuilder.DropTable(
                name: "AdminTransaction");

            migrationBuilder.DropTable(
                name: "MerchantToken");

            migrationBuilder.DropTable(
                name: "MerchantTransaction");

            migrationBuilder.DropTable(
                name: "OTP");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Merchant");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
