using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Migrations
{
    public partial class expandTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelId",
                table: "Transports",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transports_TravelId",
                table: "Transports",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Travels_TravelId",
                table: "Transports",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Travels_TravelId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_TravelId",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "Transports");
        }
    }
}
