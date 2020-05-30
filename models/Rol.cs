using System.Collections.Generic;

namespace Kalum2020_v1.models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<UsuarioRol> UsuariosRoles { get; set; }
    }
}