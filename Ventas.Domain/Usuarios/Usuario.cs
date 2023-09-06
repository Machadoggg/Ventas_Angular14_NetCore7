namespace Ventas.Domain.Usuarios
{
    public partial class Usuario
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = default!;

        public string Correo { get; set; } = default!;

        public int IdRol { get; set; }

        public string Clave { get; set; } = default!;

        public bool EsActivo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = default!;
    }
}