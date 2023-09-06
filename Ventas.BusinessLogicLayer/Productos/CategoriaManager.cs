using Ventas.DataAccessLayer.Repositorios.Contrato;
using Ventas.Domain.Productos;

namespace Ventas.BusinessLogicLayer.Productos
{
    public class CategoriaManager : ICategoriaManager
    {
        private readonly IGenericRepository<Categoria> _categoriaRepositorio;

        public CategoriaManager(IGenericRepository<Categoria> categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<Categoria>> Lista()
        {
            try
            {
                var listaCategorias = await _categoriaRepositorio.Consultar();
                return listaCategorias.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
