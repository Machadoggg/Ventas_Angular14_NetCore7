﻿namespace Ventas_Angular14_NetCore7.API.Controllers.Productos
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string? Nombre { get; set; }

        public int? IdCategoria { get; set; }

        public string? DescripcionCategoria { get; set; }

        public int? Stock { get; set; }

        public string? Precio { get; set; }

        public int? EsActivo { get; set; }
    }
}