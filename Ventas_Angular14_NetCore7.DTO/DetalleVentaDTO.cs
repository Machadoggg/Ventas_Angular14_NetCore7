﻿namespace Ventas_Angular14_NetCore7.DTO
{
    public class DetalleVentaDTO
    {
        public int? IdProducto { get; set; }

        public string? DescripcionProductos { get; set; }

        public int? Cantidad { get; set; }

        public string? PrecioTexto { get; set; }

        public string? TotalTexto { get; set; }
    }
}