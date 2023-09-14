using Ventas.BusinessLogicLayer.Comun;
using Ventas.BusinessLogicLayer.Productos;
using Ventas.DataAccessLayer.DBContext;
using Ventas.Domain.Productos;

namespace Ventas.DataAccessLayer.Repositorios
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        private readonly IGenericRepository<Categoria> _genericRepositorio;

        public CategoriaRepository(VentasAngular14Context dbContext, IGenericRepository<Categoria> genericRepositorio) : base(dbContext)
        {
            _genericRepositorio = genericRepositorio;
        }

        public async Task<List<Categoria>> ListaCategoriasAsync()
        {
            var listaCategorias = await _genericRepositorio.Consultar();
            return listaCategorias.ToList();
        }
    }
}
