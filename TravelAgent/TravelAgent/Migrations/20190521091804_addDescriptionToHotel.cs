using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Migrations
{
    public partial class addDescriptionToHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hotels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hotels");
        }
    }
}
