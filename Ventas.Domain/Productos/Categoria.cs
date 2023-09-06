namespace Ventas.Domain.Productos
{
    public partial class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = default!;

        public bool EsActivo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
