using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Migrations
{
    public partial class addEmployeeToEmployeeTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Travels");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EmployeeTravel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTravel_EmployeeId",
                table: "EmployeeTravel",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTravel_AspNetUsers_EmployeeId",
                table: "EmployeeTravel",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTravel_AspNetUsers_EmployeeId",
                table: "EmployeeTravel");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTravel_EmployeeId",
                table: "EmployeeTravel");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeTravel");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Travels",
                nullable: false,
                defaultValue: 0);
        }
    }
}
