using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BashMaistoriBG.Data.Migrations
{
    public partial class RequestModelUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_RequestorId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "RequestorId",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_RequestorId",
                table: "Requests",
                column: "RequestorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_RequestorId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "RequestorId",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_RequestorId",
                table: "Requests",
                column: "RequestorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
