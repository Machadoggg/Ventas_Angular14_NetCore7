using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ventas_Angular14_NetCore7.DTO;

namespace Ventas_Angular14_NetCore7.BLL.Servicios.Contrato
{
    public interface IVentaService
    {
        Task<VentaDTO> Registrar(VentaDTO modelo);

        Task<List<VentaDTO>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);

        Task<ReporteDTO> Reporte(string fechaInicio, string fechaFin);

    }
}
