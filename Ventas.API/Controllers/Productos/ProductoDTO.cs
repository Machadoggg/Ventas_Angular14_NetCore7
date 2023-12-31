﻿namespace Ventas.API.Controllers.Productos
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = default!;

        public int IdCategoria { get; set; }

        public string DescripcionCategoria { get; set; } = default!;

        public int Stock { get; set; }

        public string Precio { get; set; } = default!;

        public int EsActivo { get; set; }
    }
}
