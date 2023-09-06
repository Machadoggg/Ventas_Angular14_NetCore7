namespace Ventas.API.Controllers.Menus
{
    public class MenuDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = default!;

        public string Icono { get; set; } = default!;

        public string Url { get; set; } = default!;
    }
}
