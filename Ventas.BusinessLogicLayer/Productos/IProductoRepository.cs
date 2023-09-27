using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Productos;

namespace Ventas.BusinessLogicLayer.Productos
{
    public interface IProductoRepository : IProductoRepository<Producto>
    {
        Task<List<Producto>> ListaProductosAsync();
        Task<Producto> CrearProductoAsync(Producto modelo);
        Task<bool> EditarProductoAsync(Producto modelo);
        Task<bool> EliminarProductoAsync(int id);
    }
}
