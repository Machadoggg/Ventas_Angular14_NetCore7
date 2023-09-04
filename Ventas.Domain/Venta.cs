﻿namespace Ventas.Model
{
    public partial class Venta
    {
        public int IdVenta { get; set; }

        public string NumeroDocumento { get; set; }

        public string TipoPago { get; set; }

        public decimal? Total { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
    }
}