using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas_Angular14_NetCore7.API.Utilidad;
using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.Model;

namespace Ventas_Angular14_NetCore7.API.Controllers.Ventas
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaServicio;
        private readonly IMapper _mapper;

        public VentaController(IVentaService ventaServicio, IMapper mapper)
        {
            _ventaServicio = ventaServicio;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO venta)
        {
            var respuesta = new Response<VentaDTO>();

            try
            {
                var modelo = _mapper.Map<Venta>(venta);
                var ventaCreada = await _ventaServicio.Registrar(modelo);
                respuesta.Value = _mapper.Map<VentaDTO>(ventaCreada);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(400, respuesta);
            }
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
                var resultado = await _ventaServicio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin).ConfigureAwait(false);
                respuesta.Value = _mapper.Map<List<VentaDTO>>(resultado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(404, respuesta);
            }
        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            var respuesta = new Response<List<ReporteDTO>>();


            try
            {
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
