using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class refresh_token_successor_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "IsStopped",
                table: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "RefreshToken",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Successor",
                table: "RefreshToken",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WasUsed",
                table: "RefreshToken",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_Successor",
                table: "RefreshToken",
                column: "Successor",
                unique: true,
                filter: "[Successor] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_RefreshToken",
                table: "RefreshToken",
                column: "Successor",
                principalTable: "RefreshToken",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_Successor",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Successor",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "WasUsed",
                table: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "RefreshToken",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsStopped",
                table: "RefreshToken",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Token");
        }
    }
}
