namespace Ventas.Domain.Ventas
{
    public partial class Venta
    {
        public int Id { get; set; }

        public string NumeroDocumento { get; set; } = default!;

        public string TipoPago { get; set; } = default!;

        public decimal Total { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
    }
}