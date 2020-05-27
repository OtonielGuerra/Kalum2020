using System.Collections.Generic;

namespace Kalum2020_v1.models
{
    public class Salon
    {
        public int SalonId { get; set; }
        public string NombreSalon { get; set; }
        public string  Descripcion { get; set; }
        public int Cantidad { get; set; }
        public virtual List<Clase> Clases {get; set;}
    }
}