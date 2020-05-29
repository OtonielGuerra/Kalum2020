using System.Collections.Generic;

namespace Kalum2020_v1.models
{
    public class Usuario
    {
        public int Id { get; set; }   
        public string Username { get; set; }
        public int Enabled { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public List<UsuarioRol> UsuarioRoles { get; set; }
    }
}