using System;
using System.Collections.Generic;

namespace Kalum2020_v1.models
{
    public class Horario
    {
        public int HorarioId { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFinal { get; set; }
        public virtual List<Clase> Clases {get; set;}
    }
}