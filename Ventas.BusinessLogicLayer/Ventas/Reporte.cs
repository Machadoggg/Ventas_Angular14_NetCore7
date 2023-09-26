namespace Ventas.BusinessLogicLayer
{
    public class Reporte
    {
        public string NumeroDocumento { get; set; } = default!;
        public string TipoPago { get; set; } = default!;
        public string FechaRegistro { get; set; } = default!;

        public string TotalVenta { get; set; } = default!;
        public string Producto { get; set; } = default!;
        public int Cantidad { get; set; }
        public string Precio { get; set; } = default!;
        public string Total { get; set; } = default!;   
    }
}
