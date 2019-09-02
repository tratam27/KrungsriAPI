using Microsoft.EntityFrameworkCore.Migrations;

namespace Krungsri.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminTransaction_User_UserId",
                table: "AdminTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AdminTransaction_UserId",
                table: "AdminTransaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AdminTransaction_UserId",
                table: "AdminTransaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTransaction_User_UserId",
                table: "AdminTransaction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
