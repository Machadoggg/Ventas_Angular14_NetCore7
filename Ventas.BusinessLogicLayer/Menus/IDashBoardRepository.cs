using Ventas.BusinessLogicLayer.Comun;

namespace Ventas.BusinessLogicLayer.Menus
{
    public interface IDashBoardRepository : IGenericRepository<DashBoard>
    {
        Task<DashBoard> ResumenAsync();
    }
}
