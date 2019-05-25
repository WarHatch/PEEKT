using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Migrations
{
    public partial class insertEmployeesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Offices_RegisteredOfficeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredOfficeId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Available", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePhoto", "RegisteredOfficeId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, true, "b75058a6-2dcf-4fd4-9a27-c4b4cc77271c", "paulius.grigaliunas.pg@gmail.com", false, "Paulius", "Grigaliūnas", false, null, null, null, null, null, false, "https://www.w3schools.com/howto/img_avatar.png", 1, null, false, null },
                    { 2, 0, false, "da7edba5-7151-422b-9494-73ef03d6f495", "emilija.lamanauskaite@gmail.com", false, "Emilija", "Lamanauskaite", false, null, null, null, null, null, false, "https://www.w3schools.com/howto/img_avatar2.png", 1, null, false, null },
                    { 3, 0, true, "8d6bf079-f153-41ad-9921-1992f077737c", "elena.reivytyte@gmail.com", false, "Elena", "Reivytytė", false, null, null, null, null, null, false, "https://www.w3schools.com/howto/img_avatar2.png", 1, null, false, null },
                    { 4, 0, true, "8cfcef72-2f87-46ca-9f12-7ac0e569710c", "karolis.staskevicius@gmail.com", false, "Karolis", "Staskevičius", false, null, null, null, null, null, false, "https://www.w3schools.com/howto/img_avatar.png", 2, null, false, null },
                    { 5, 0, true, "69152d97-c069-413c-8a08-ef5430f3e0c6", "tomas.kazlauskas@gmail.com", false, "Tomas", "Kazlauskas", false, null, null, null, null, null, false, "https://www.w3schools.com/howto/img_avatar.png", 3, null, false, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Offices_RegisteredOfficeId",
                table: "AspNetUsers",
                column: "RegisteredOfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Offices_RegisteredOfficeId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredOfficeId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Offices_RegisteredOfficeId",
                table: "AspNetUsers",
                column: "RegisteredOfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
