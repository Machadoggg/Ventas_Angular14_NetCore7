using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Usuarios;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public interface IRolRepository : IProductoRepository<Rol>
    {
        Task<List<Rol>> ListaRolesAsync();
    }
}
