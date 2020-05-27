using System.Collections.Generic;

namespace Kalum2020_v1.models
{
    public class CarreraTecnica
    {
        public int CarreraTecnicaId { get; set; }
        public string NombreCarrera { get; set; }
        public virtual List<Clase> Clases {get; set;}

    }
}