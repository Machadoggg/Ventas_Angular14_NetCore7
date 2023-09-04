using Ventas.Model;

namespace Ventas.BusinessLogicLayer.ProductoServices
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> Lista();
    }
}
