namespace Ventas.BusinessLogicLayer.Menus
{
    public interface IDashBoardManager
    {
        Task<DashBoardDTO> Resumen();
    }
}
