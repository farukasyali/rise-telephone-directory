using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PhoneBook.Services.PersonApi.Migrations
{
    public partial class AddContactType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactType",
                table: "PersonContact",
                newName: "ContactTypeId");

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_ContactTypeId",
                table: "PersonContact",
                column: "ContactTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContact_ContactType_ContactTypeId",
                table: "PersonContact",
                column: "ContactTypeId",
                principalTable: "ContactType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonContact_ContactType_ContactTypeId",
                table: "PersonContact");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropIndex(
                name: "IX_PersonContact_ContactTypeId",
                table: "PersonContact");

            migrationBuilder.RenameColumn(
                name: "ContactTypeId",
                table: "PersonContact",
                newName: "ContactType");
        }
    }
}
