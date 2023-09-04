using Ventas.Model;

namespace Ventas.BusinessLogicLayer.VentaServices
{
    public interface IVentaService
    {
        Task<Venta> Registrar(Venta modelo);

        Task<List<Venta>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);

        Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin);

    }
}
