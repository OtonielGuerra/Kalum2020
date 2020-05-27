using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020_v1.Migrations
{
    public partial class CompleteModelKalum2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_CarreraTecnicas_CarreraTecnicaId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Instructors_InstructorId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Salons_SalonId",
                table: "Clases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salons",
                table: "Salons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarreraTecnicas",
                table: "CarreraTecnicas");

            migrationBuilder.RenameTable(
                name: "Salons",
                newName: "Salones");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructores");

            migrationBuilder.RenameTable(
                name: "CarreraTecnicas",
                newName: "CarrerasTecnicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salones",
                table: "Salones",
                column: "SalonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructores",
                table: "Instructores",
                column: "InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrerasTecnicas",
                table: "CarrerasTecnicas",
                column: "CarreraTecnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_CarrerasTecnicas_CarreraTecnicaId",
                table: "Clases",
                column: "CarreraTecnicaId",
                principalTable: "CarrerasTecnicas",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Instructores_InstructorId",
                table: "Clases",
                column: "InstructorId",
                principalTable: "Instructores",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Salones_SalonId",
                table: "Clases",
                column: "SalonId",
                principalTable: "Salones",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_CarrerasTecnicas_CarreraTecnicaId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Instructores_InstructorId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Salones_SalonId",
                table: "Clases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salones",
                table: "Salones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructores",
                table: "Instructores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrerasTecnicas",
                table: "CarrerasTecnicas");

            migrationBuilder.RenameTable(
                name: "Salones",
                newName: "Salons");

            migrationBuilder.RenameTable(
                name: "Instructores",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "CarrerasTecnicas",
                newName: "CarreraTecnicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salons",
                table: "Salons",
                column: "SalonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarreraTecnicas",
                table: "CarreraTecnicas",
                column: "CarreraTecnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_CarreraTecnicas_CarreraTecnicaId",
                table: "Clases",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnicas",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Instructors_InstructorId",
                table: "Clases",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Salons_SalonId",
                table: "Clases",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
