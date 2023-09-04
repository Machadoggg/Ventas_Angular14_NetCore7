using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Ventas
{
    public interface IVentaManager
    {
        Task<Venta> Registrar(Venta modelo);

        Task<List<Venta>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);

        Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin);

    }
}
