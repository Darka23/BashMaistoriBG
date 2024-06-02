using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BashMaistoriBG.Data.Migrations
{
    public partial class UpdateRequestSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialistType",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "SpecialtyName",
                table: "Specialties",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "RequestListViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserEditViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEditViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SpecialtyId",
                table: "Requests",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Specialties_SpecialtyId",
                table: "Requests",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Specialties_SpecialtyId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "UserEditViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Requests_SpecialtyId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RequestListViewModel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Specialties",
                newName: "SpecialtyName");

            migrationBuilder.AddColumn<string>(
                name: "SpecialistType",
                table: "Requests",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }
    }
}
