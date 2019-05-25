using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Migrations
{
    public partial class insertEmployeesData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "1c14ef9e-964c-4721-a3da-7a6e59032c20", "paulius.grigaliunas.pg@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "c99c5b44-dbb5-4c24-8b5c-176985f1bc9d", "emilija.lamanauskaite@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "7e360d81-71bb-45d0-8a5d-931dc1e46553", "elena.reivytyte@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "c9bfb2cb-1e03-400f-b672-4f4d09d8efbc", "karolis.staskevicius@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "21692747-5be7-4095-b5c7-e2e36e255430", "tomas.kazlauskas@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "3bae154c-450f-4fed-83c7-0d155e06fae4", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "612974b3-702e-4130-9aab-bef6f8428584", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "a57f64ed-277f-4c44-96e9-e203f5318e36", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "eb0bb414-1269-49a2-9ca3-fba76723a375", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "204e4e04-c178-48d7-bb8a-f1d6f04c6c02", null });
        }
    }
}
