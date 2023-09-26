namespace Ventas.BusinessLogicLayer
{
    public class DashBoard
    {
        public int TotalVentas { get; set; }
        public string? TotalIngresos { get; set; }
        public int TotalProductos { get; set; }
        public List<VentasSemana>? VentasUltimaSemana { get; set; }
    }
}
