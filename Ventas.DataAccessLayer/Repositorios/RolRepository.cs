using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.DataAccessLayer.DBContext;
using Ventas.Domain.Usuarios;

namespace Ventas.DataAccessLayer.Repositorios
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly VentasAngular14Context _dbcontext;

        public RolRepository(VentasAngular14Context dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Rol>> ListaRolesAsync()
        {
            try
            {
                var listaRoles = await _dbcontext.Rols.ToListAsync();
                return listaRoles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
