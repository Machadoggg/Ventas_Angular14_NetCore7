﻿namespace Ventas.API.Controllers.Ventas
{
    public class VentaDTO
    {
        public int Id { get; set; }

        public string NumeroDocumento { get; set; }

        public string TipoPago { get; set; }

        public string TotalTexto { get; set; }

        public string FechaRegistro { get; set; }


        public virtual ICollection<DetalleVentaDTO>? DetalleVenta { get; set; }

    }
}
