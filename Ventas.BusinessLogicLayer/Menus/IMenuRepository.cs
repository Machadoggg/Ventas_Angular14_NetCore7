using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Menus;

namespace Ventas.BusinessLogicLayer.Menus
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        public Task<List<Menu>> ObtenerMenuPorIdAsync(int id);
    }
}
