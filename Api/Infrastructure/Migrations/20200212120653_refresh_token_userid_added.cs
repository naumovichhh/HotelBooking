using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class refresh_token_userid_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "RefreshToken",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_User",
                table: "RefreshToken",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User",
                table: "RefreshToken",
                column: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_User",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "User",
                table: "RefreshToken");
        }
    }
}
