using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Menus;
using Ventas.Domain.Usuarios;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        public Task<List<Menu>> ObtenerMenuPorIdAsync(int id);
    }
}
