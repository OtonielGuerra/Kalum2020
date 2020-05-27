using Microsoft.EntityFrameworkCore.Migrations;

namespace Kalum2020_v1.Migrations
{
    public partial class CompleteModelKalum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumno_Alumnos_AlumnoId",
                table: "AsignacionAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumno_Clase_ClaseId",
                table: "AsignacionAlumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_CarreraTecnica_CarreraTecnicaId",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Horario_HorarioId",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Instructor_InstructorId",
                table: "Clase");

            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Salon_SalonId",
                table: "Clase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salon",
                table: "Salon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Horario",
                table: "Horario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clase",
                table: "Clase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarreraTecnica",
                table: "CarreraTecnica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AsignacionAlumno",
                table: "AsignacionAlumno");

            migrationBuilder.RenameTable(
                name: "Salon",
                newName: "Salons");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "Horario",
                newName: "Horarios");

            migrationBuilder.RenameTable(
                name: "Clase",
                newName: "Clases");

            migrationBuilder.RenameTable(
                name: "CarreraTecnica",
                newName: "CarreraTecnicas");

            migrationBuilder.RenameTable(
                name: "AsignacionAlumno",
                newName: "AsignacionAlumnos");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_SalonId",
                table: "Clases",
                newName: "IX_Clases_SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_InstructorId",
                table: "Clases",
                newName: "IX_Clases_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_HorarioId",
                table: "Clases",
                newName: "IX_Clases_HorarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Clase_CarreraTecnicaId",
                table: "Clases",
                newName: "IX_Clases_CarreraTecnicaId");

            migrationBuilder.RenameIndex(
                name: "IX_AsignacionAlumno_ClaseId",
                table: "AsignacionAlumnos",
                newName: "IX_AsignacionAlumnos_ClaseId");

            migrationBuilder.RenameIndex(
                name: "IX_AsignacionAlumno_AlumnoId",
                table: "AsignacionAlumnos",
                newName: "IX_AsignacionAlumnos_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salons",
                table: "Salons",
                column: "SalonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horarios",
                table: "Horarios",
                column: "HorarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clases",
                table: "Clases",
                column: "ClaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarreraTecnicas",
                table: "CarreraTecnicas",
                column: "CarreraTecnicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AsignacionAlumnos",
                table: "AsignacionAlumnos",
                column: "AsignacionAlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumnos_Alumnos_AlumnoId",
                table: "AsignacionAlumnos",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "AlumnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumnos_Clases_ClaseId",
                table: "AsignacionAlumnos",
                column: "ClaseId",
                principalTable: "Clases",
                principalColumn: "ClaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_CarreraTecnicas_CarreraTecnicaId",
                table: "Clases",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnicas",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Horarios_HorarioId",
                table: "Clases",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumnos_Alumnos_AlumnoId",
                table: "AsignacionAlumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_AsignacionAlumnos_Clases_ClaseId",
                table: "AsignacionAlumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_CarreraTecnicas_CarreraTecnicaId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Horarios_HorarioId",
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
                name: "PK_Horarios",
                table: "Horarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clases",
                table: "Clases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarreraTecnicas",
                table: "CarreraTecnicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AsignacionAlumnos",
                table: "AsignacionAlumnos");

            migrationBuilder.RenameTable(
                name: "Salons",
                newName: "Salon");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameTable(
                name: "Horarios",
                newName: "Horario");

            migrationBuilder.RenameTable(
                name: "Clases",
                newName: "Clase");

            migrationBuilder.RenameTable(
                name: "CarreraTecnicas",
                newName: "CarreraTecnica");

            migrationBuilder.RenameTable(
                name: "AsignacionAlumnos",
                newName: "AsignacionAlumno");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_SalonId",
                table: "Clase",
                newName: "IX_Clase_SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_InstructorId",
                table: "Clase",
                newName: "IX_Clase_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_HorarioId",
                table: "Clase",
                newName: "IX_Clase_HorarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_CarreraTecnicaId",
                table: "Clase",
                newName: "IX_Clase_CarreraTecnicaId");

            migrationBuilder.RenameIndex(
                name: "IX_AsignacionAlumnos_ClaseId",
                table: "AsignacionAlumno",
                newName: "IX_AsignacionAlumno_ClaseId");

            migrationBuilder.RenameIndex(
                name: "IX_AsignacionAlumnos_AlumnoId",
                table: "AsignacionAlumno",
                newName: "IX_AsignacionAlumno_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salon",
                table: "Salon",
                column: "SalonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horario",
                table: "Horario",
                column: "HorarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clase",
                table: "Clase",
                column: "ClaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarreraTecnica",
                table: "CarreraTecnica",
                column: "CarreraTecnicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AsignacionAlumno",
                table: "AsignacionAlumno",
                column: "AsignacionAlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumno_Alumnos_AlumnoId",
                table: "AsignacionAlumno",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "AlumnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsignacionAlumno_Clase_ClaseId",
                table: "AsignacionAlumno",
                column: "ClaseId",
                principalTable: "Clase",
                principalColumn: "ClaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_CarreraTecnica_CarreraTecnicaId",
                table: "Clase",
                column: "CarreraTecnicaId",
                principalTable: "CarreraTecnica",
                principalColumn: "CarreraTecnicaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Horario_HorarioId",
                table: "Clase",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Instructor_InstructorId",
                table: "Clase",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Salon_SalonId",
                table: "Clase",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
