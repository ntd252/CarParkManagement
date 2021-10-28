using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class carkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "Tickets",
                type: "nvarchar(50)",
                nullable: true);
        }
    }
}
