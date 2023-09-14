using Ventas.Domain.Productos;

namespace Ventas.BusinessLogicLayer.Productos
{
    public class ProductoManager : IProductoManager
    {
        private readonly IProductoRepository _productoRepositorio;

        public ProductoManager(IProductoRepository productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }


        public async Task<List<Producto>> Lista()
        {
            var queryProducto = await _productoRepositorio.ListaProductosAsync().ConfigureAwait(false);
            return queryProducto;
        }

        public async Task<Producto> Crear(Producto modelo)
        {
            var productoCreado = await _productoRepositorio.CrearProductoAsync(modelo).ConfigureAwait(false);
            return productoCreado;
        }

        public async Task<bool> Editar(Producto modelo)
        {
            var productoEncontrado = await _productoRepositorio.EditarProductoAsync(modelo).ConfigureAwait(false);
            return productoEncontrado;
        }

        public async Task<bool> Eliminar(int id)
        {
            var productoEncontrado = await _productoRepositorio.EliminarProductoAsync(id).ConfigureAwait(false);
            return productoEncontrado;
        }
    }
}
