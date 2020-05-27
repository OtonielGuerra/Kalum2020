using System;
using System.Collections.Generic;

namespace Kalum2020_v1.models
{
    public class Alumno
    {
        public int AlumnoId {get; set;}
        public int Carne { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public virtual List<AsignacionAlumno> AsignacionAlumnos { get; set; }
    }
}