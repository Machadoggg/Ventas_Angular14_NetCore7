namespace Ventas.BusinessLogicLayer.MenuServices
{
    public interface IDashBoardService
    {
        Task<DashBoardDTO> Resumen();
    }
}
