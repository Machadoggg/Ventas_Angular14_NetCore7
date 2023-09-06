namespace Ventas.Model
{
    public partial class Rol
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = default!;

        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}