﻿// <auto-generated />
using System;
using Kalum2020_v1.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kalum2020_v1.Migrations
{
    [DbContext(typeof(KalumDB))]
    partial class KalumDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kalum2020_v1.models.Alumno", b =>
                {
                    b.Property<int>("AlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Carne")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlumnoId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("Kalum2020_v1.models.AsignacionAlumno", b =>
                {
                    b.Property<int>("AsignacionAlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AsignacionAlumnoId");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("ClaseId");

                    b.ToTable("AsignacionAlumnos");
                });

            modelBuilder.Entity("Kalum2020_v1.models.CarreraTecnica", b =>
                {
                    b.Property<int>("CarreraTecnicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreCarrera")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarreraTecnicaId");

                    b.ToTable("CarrerasTecnicas");
                });

            modelBuilder.Entity("Kalum2020_v1.models.Clase", b =>
                {
                    b.Property<int>("ClaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadAsignaciones")
                        .HasColumnType("int");

                    b.Property<int>("CarreraTecnicaId")
                        .HasColumnType("int");

                    b.Property<int>("Ciclo")
                        .HasColumnType("int");

                    b.Property<int>("CupoMaximo")
                        .HasColumnType("int");

                    b.Property<int>("CupoMinimo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorarioId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("SalonId")
                        .HasColumnType("int");

                    b.HasKey("ClaseId");

                    b.HasIndex("CarreraTecnicaId");

                    b.HasIndex("HorarioId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("SalonId");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("Kalum2020_v1.models.Horario", b =>
                {
                    b.Property<int>("HorarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HorarioFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HorarioInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("HorarioId");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Kalum2020_v1.models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructores");
                });

            modelBuilder.Entity("Kalum2020_v1.models.Salon", b =>
                {
                    b.Property<int>("SalonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreSalon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalonId");

                    b.ToTable("Salones");
                });

            modelBuilder.Entity("Kalum2020_v1.models.AsignacionAlumno", b =>
                {
                    b.HasOne("Kalum2020_v1.models.Alumno", "Alumno")
                        .WithMany("AsignacionAlumnos")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kalum2020_v1.models.Clase", "Clase")
                        .WithMany("AsignacionAlumnos")
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kalum2020_v1.models.Clase", b =>
                {
                    b.HasOne("Kalum2020_v1.models.CarreraTecnica", "CarreraTecnica")
                        .WithMany("Clases")
                        .HasForeignKey("CarreraTecnicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kalum2020_v1.models.Horario", "Horario")
                        .WithMany("Clases")
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kalum2020_v1.models.Instructor", "Instructor")
                        .WithMany("Clases")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kalum2020_v1.models.Salon", "Salon")
                        .WithMany("Clases")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
