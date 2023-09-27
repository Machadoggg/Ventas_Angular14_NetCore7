using Ventas.BusinessLogicLayer.Comun;

namespace Ventas.BusinessLogicLayer.Menus
{
    public interface IDashBoardRepository : IProductoRepository<DashBoard>
    {
        Task<DashBoard> ResumenAsync();
    }
}
