namespace Ventas.Model
{
    public partial class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = default!;

        public int IdCategoria { get; set; }

        public int Stock { get; set; }

        public decimal Precio { get; set; }

        public bool EsActivo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

        public virtual Categoria IdCategoriaNavigation { get; set; } = default!;
    }
}