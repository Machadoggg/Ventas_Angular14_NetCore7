using Ventas.Domain.Productos;

namespace Ventas.BusinessLogicLayer.Productos
{
    public class CategoriaManager : ICategoriaManager
    {
        private readonly ICategoriaRepository _categoriaRepositorio;

        public CategoriaManager(ICategoriaRepository categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<Categoria>> Lista()
        {
            var listaCategorias = await _categoriaRepositorio.ListaCategoriasAsync().ConfigureAwait(false);
            return listaCategorias.ToList();

        }
    }
}
