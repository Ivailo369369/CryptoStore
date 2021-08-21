using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoStore.Data.Migrations
{
    public partial class CryptoTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CryptoToken",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "CryptoTokens",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CryptoTokens",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "CryptoToken",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
