namespace Ventas.Domain.Menus
{
    public partial class Menu
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = default!;

        public string Icono { get; set; } = default!;

        public string Url { get; set; } = default!;

        public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();
    }
}