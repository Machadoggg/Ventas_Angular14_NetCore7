using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Productos;

namespace Ventas.BusinessLogicLayer.Productos
{
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        Task<List<Categoria>> ListaCategoriasAsync();
    }
}
