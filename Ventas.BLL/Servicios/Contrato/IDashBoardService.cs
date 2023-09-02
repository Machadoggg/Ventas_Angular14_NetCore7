namespace Ventas_Angular14_NetCore7.BLL.Servicios.Contrato
{
    public interface IDashBoardService
    {
        Task<DashBoardDTO> Resumen();
    }
}
