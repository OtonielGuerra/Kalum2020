using System;
using System.Collections.Generic;

namespace Kalum2020_v1.models
{
    public class AsignacionAlumno
    {
        public int AsignacionAlumnoId { get; set; }
        public int ClaseId { get; set; }
        public int AlumnoId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public string Observacion { get; set; }
        public virtual Clase Clase { get; set; }
        public virtual Alumno Alumno { get; set; }
    }
}