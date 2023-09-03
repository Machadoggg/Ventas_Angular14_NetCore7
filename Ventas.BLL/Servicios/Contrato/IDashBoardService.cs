namespace Ventas.BLL.Servicios.Contrato
{
    public interface IDashBoardService
    {
        Task<DashBoardDTO> Resumen();
    }
}
