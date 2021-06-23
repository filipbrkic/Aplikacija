using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.DAL.Migrations
{
    public partial class DbContextChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Seminar_SeminarId",
                table: "Registration");

            migrationBuilder.DropForeignKey(
                name: "FK_Seminar_AspNetUsers_UserId",
                table: "Seminar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seminar",
                table: "Seminar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registration",
                table: "Registration");

            migrationBuilder.RenameTable(
                name: "Seminar",
                newName: "Seminars");

            migrationBuilder.RenameTable(
                name: "Registration",
                newName: "Registrations");

            migrationBuilder.RenameIndex(
                name: "IX_Seminar_UserId",
                table: "Seminars",
                newName: "IX_Seminars_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_SeminarId",
                table: "Registrations",
                newName: "IX_Registrations_SeminarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seminars",
                table: "Seminars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Seminars_SeminarId",
                table: "Registrations",
                column: "SeminarId",
                principalTable: "Seminars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_AspNetUsers_UserId",
                table: "Seminars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Seminars_SeminarId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_AspNetUsers_UserId",
                table: "Seminars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seminars",
                table: "Seminars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations");

            migrationBuilder.RenameTable(
                name: "Seminars",
                newName: "Seminar");

            migrationBuilder.RenameTable(
                name: "Registrations",
                newName: "Registration");

            migrationBuilder.RenameIndex(
                name: "IX_Seminars_UserId",
                table: "Seminar",
                newName: "IX_Seminar_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Registrations_SeminarId",
                table: "Registration",
                newName: "IX_Registration_SeminarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seminar",
                table: "Seminar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registration",
                table: "Registration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Seminar_SeminarId",
                table: "Registration",
                column: "SeminarId",
                principalTable: "Seminar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seminar_AspNetUsers_UserId",
                table: "Seminar",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
