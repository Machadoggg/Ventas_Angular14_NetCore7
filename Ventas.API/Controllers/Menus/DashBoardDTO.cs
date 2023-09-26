﻿using Ventas.BusinessLogicLayer;

namespace Ventas.API.Controllers.Menus
{
    public class DashBoardDTO
    {
        public int TotalVentas { get; set; }
        public string? TotalIngresos { get; set; }
        public int TotalProductos { get; set; }
        public List<VentasSemana>? VentasUltimaSemana { get; set; }
    }
}
