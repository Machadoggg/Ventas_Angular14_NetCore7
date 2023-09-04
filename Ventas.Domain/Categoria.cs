﻿namespace Ventas.Model
{
    public partial class Categoria
    {
        public int IdCategoria { get; set; }

        public string Nombre { get; set; }

        public bool EsActivo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
