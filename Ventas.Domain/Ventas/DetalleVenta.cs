using Ventas.Domain.Productos;

namespace Ventas.Domain.Ventas
{
    public partial class DetalleVenta
    {
        public int Id { get; set; }

        public int IdVenta { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Total { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = default!;

        public virtual Venta IdVentaNavigation { get; set; } = default!;
    }
}