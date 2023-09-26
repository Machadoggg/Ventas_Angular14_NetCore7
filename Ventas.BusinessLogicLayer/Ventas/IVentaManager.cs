using Ventas.Domain.Ventas;

namespace Ventas.BusinessLogicLayer.Ventas
{
    public interface IVentaManager
    {
        Task<Venta> Registrar(Venta modelo);

        Task<List<Venta>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);

        Task<List<Reporte>> Reporte(string fechaInicio, string fechaFin);

    }
}
