using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoStore.Data.Migrations
{
    public partial class PaymentUsernameClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsernameClient",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsernameClient",
                table: "Payments");
        }
    }
}
