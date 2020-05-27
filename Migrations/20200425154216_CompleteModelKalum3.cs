using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020_v1.Migrations
{
    public partial class CompleteModelKalum3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_CarrerasTecnicas_CarreraTecnicaId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Instructores_InstructorId",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "CarreraId",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "IstructorId",
                table: "Clases");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Clases",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarreraTecnicaId",
                table: "Clases",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_CarrerasTecnicas_CarreraTecnicaId",
                table: "Clases",
                column: "CarreraTecnicaId",
                principalTable: "CarrerasTecnicas",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Instructores_InstructorId",
                table: "Clases",
                column: "InstructorId",
                principalTable: "Instructores",
                principalColumn: "InstructorId",
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

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Clases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CarreraTecnicaId",
                table: "Clases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CarreraId",
                table: "Clases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IstructorId",
                table: "Clases",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
