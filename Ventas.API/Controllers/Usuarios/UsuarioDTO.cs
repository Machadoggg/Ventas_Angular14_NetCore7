﻿namespace Ventas.API.Controllers.Usuarios
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public int IdRol { get; set; }

        public string RolDescripcion { get; set; }

        public string Clave { get; set; }

        public int EsActivo { get; set; }
    }
}
