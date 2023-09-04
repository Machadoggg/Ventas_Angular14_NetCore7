using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Productos
{
    public interface ICategoriaManager
    {
        Task<List<Categoria>> Lista();
    }
}
