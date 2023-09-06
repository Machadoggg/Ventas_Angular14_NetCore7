using Ventas.Domain.Productos;

namespace Ventas.BusinessLogicLayer.Productos
{
    public interface ICategoriaManager
    {
        Task<List<Categoria>> Lista();
    }
}
