using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Migrations
{
    public partial class deleteTravelFromHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "Hotels");
        }
    }
}
