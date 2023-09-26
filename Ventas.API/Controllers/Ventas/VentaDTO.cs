namespace Ventas.API.Controllers.Ventas
{
    public class VentaDTO
    {
        public int Id { get; set; }

        public string NumeroDocumento { get; set; } = default!;

        public string TipoPago { get; set; } = default!;

        public string TotalTexto { get; set; } = default!;

        public string FechaRegistro { get; set; } = default!;


        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; } = default!;

    }
}
