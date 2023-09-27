using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Productos;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios.Comun;
using Ventas.Domain.Productos;

namespace Ventas.DataAccessLayer.Repositorios.Productos
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(VentasAngular14Context dbcontext) : base(dbcontext)
        {
        }

        public async Task<List<Categoria>> ListaCategoriasAsync()
        {
            try
            {
                var queryCategoria = Consultar();
                var listaCategorias = await queryCategoria.ToListAsync();
                return listaCategorias;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
