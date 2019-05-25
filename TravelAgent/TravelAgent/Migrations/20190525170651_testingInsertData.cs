using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Migrations
{
    public partial class testingInsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Address", "FitsPeople", "Title" },
                values: new object[,]
                {
                    { 1, "Žalgirio g. 135, Vilnius 08217", 6, "Devbridge Vilnius Apartament" },
                    { 2, "A. Juozapavičiaus pr. 11 D, Kaunas 45252", 6, "Devbridge Kaunas Apartament" },
                    { 3, "343 W. Erie St. Suite 600 Chicago, IL 60654", 6, "Devbridge Chicago Apartament" },
                    { 4, "36 Toronto Street Suite 260 Toronto, Ontarion M5C 2C5", 6, "Devbridge Toronto Apartament" },
                    { 5, "8 Devonshire Square London EC2M 4PL", 6, "Devbridge London Apartament" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Address", "OfficeApartmentId", "Title" },
                values: new object[,]
                {
                    { 1, "Žalgirio g. 135, Vilnius 08217", 1, "Devbridge Vilnius" },
                    { 2, "A. Juozapavičiaus pr. 11 D, Kaunas 45252", 2, "Devbridge Kaunas" },
                    { 3, "343 W. Erie St. Suite 600 Chicago, IL 60654", 3, "Devbridge Chicago" },
                    { 4, "36 Toronto Street Suite 260 Toronto, Ontarion M5C 2C5", 4, "Devbridge Toronto" },
                    { 5, "8 Devonshire Square London EC2M 4PL", 5, "Devbridge London" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
