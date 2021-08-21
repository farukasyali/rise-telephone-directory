using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Services.PersonApi.Migrations
{
    public partial class SeedContactTypeValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "Telefon No" },
                    { 2, "E-mail" },
                    { 3, "Konum" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactType",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
