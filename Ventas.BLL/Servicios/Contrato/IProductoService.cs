using Ventas.Model;

namespace Ventas.BLL.Servicios.Contrato
{
    public interface IProductoService
    {
        Task<List<Producto>> Lista();
        Task<Producto> Crear(Producto modelo);
        Task<bool> Editar(Producto modelo);
        Task<bool> Eliminar(int id);
    }
}
