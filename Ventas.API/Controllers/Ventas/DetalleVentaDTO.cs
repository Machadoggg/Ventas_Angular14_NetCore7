namespace Ventas.API.Controllers.Ventas
{
    public class DetalleVentaDTO
    {
        public int IdProducto { get; set; }

        public string DescripcionProducto { get; set; } = default!;

        public int Cantidad { get; set; }

        public string PrecioTexto { get; set; } = default!;

        public string TotalTexto { get; set; } = default!;
    }
}
