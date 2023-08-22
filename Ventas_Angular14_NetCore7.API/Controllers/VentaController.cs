using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.API.Utilidad;

namespace Ventas_Angular14_NetCore7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaServicio;

        public VentaController(IVentaService ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO venta)
        {
            var respuesta = new Response<VentaDTO>();

            try
            {
                respuesta.Ok = true;
                respuesta.Value = await _ventaServicio.Registrar(venta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio, string? fechaFin)
        {
            var respuesta = new Response<List<VentaDTO>>();
            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;


            try
            {
                respuesta.Ok = true;
                respuesta.Value = await _ventaServicio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            var respuesta = new Response<List<ReporteDTO>>();


            try
            {
                respuesta.Ok = true;
                respuesta.Value = await _ventaServicio.Reporte(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
