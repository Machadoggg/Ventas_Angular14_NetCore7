using Ventas.BusinessLogicLayer.Comun;

namespace Ventas.BusinessLogicLayer.Menus
{
    public interface IDashBoardRepository : IGenericRepository<DashBoardDTO>
    {
        Task<DashBoardDTO> ResumenAsync();
    }
}
