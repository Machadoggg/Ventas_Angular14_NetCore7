using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios.Comun;
using Ventas.Domain.Usuarios;

namespace Ventas.DataAccessLayer.Repositorios.Usuarios
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {

        public RolRepository(VentasAngular14Context dbcontext) : base(dbcontext)
        {
        }

        public async Task<List<Rol>> ListaRolesAsync()
        {
            try
            {
                var queryRoles = Consultar();
                var listaRoles = await queryRoles.ToListAsync();
                return listaRoles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
