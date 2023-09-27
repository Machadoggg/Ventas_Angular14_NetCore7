using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Menus;

namespace Ventas.BusinessLogicLayer.Menus
{
    public interface IMenuRepository : IProductoRepository<Menu>
    {
        public Task<List<Menu>> ObtenerMenuPorIdAsync(int id);
    }
}
