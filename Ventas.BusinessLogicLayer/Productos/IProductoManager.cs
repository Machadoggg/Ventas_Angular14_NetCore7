using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Productos
{
    public interface IProductoManager
    {
        Task<List<Producto>> Lista();
        Task<Producto> Crear(Producto modelo);
        Task<bool> Editar(Producto modelo);
        Task<bool> Eliminar(int id);
    }
}
