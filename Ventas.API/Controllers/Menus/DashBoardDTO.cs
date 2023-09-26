using Ventas.BusinessLogicLayer;

namespace Ventas.API.Controllers.Menus
{
    public class DashBoardDTO
    {
        public int TotalVentas { get; set; }
        public string TotalIngresos { get; set; } = default!;
        public int TotalProductos { get; set; }
        public List<VentasSemana> VentasUltimaSemana { get; set; } = default!;
    }
}
