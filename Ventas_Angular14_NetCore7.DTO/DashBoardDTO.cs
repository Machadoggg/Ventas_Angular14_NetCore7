namespace Ventas_Angular14_NetCore7.DTO
{
    public class DashBoardDTO
    {
        public int TotalVentas { get; set; }
        public string? TotalIngresos { get; set; }
        public List<VentasSemanaDTO>? VentasUltimaSemana { get; set; }
    }
}
