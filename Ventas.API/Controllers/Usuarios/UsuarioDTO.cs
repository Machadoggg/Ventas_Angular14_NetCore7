namespace Ventas.API.Controllers.Usuarios
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = default!;

        public string Correo { get; set; } = default!;

        public int IdRol { get; set; }

        public string RolDescripcion { get; set; } = default!;

        public string Clave { get; set; } = default!;

        public int EsActivo { get; set; }
    }
}
