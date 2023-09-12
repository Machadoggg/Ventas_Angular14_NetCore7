using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.DataAccessLayer.DBContext;
using Ventas.Domain.Menus;
using Ventas.Domain.Usuarios;

namespace Ventas.DataAccessLayer.Repositorios
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly VentasAngular14Context _dbContext;

        public UsuarioRepository(VentasAngular14Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Menu>> ObtenerMenuPorIdAsync(int id)
        {
            try
            {
                var listaMenus = await (from u in _dbContext.Usuarios
                                        join mr in _dbContext.MenuRols on u.IdRol equals mr.IdRol
                                        join m in _dbContext.Menus on mr.IdMenu equals m.Id
                                        where u.Id == id
                                        select m).ToListAsync();
                return listaMenus;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
