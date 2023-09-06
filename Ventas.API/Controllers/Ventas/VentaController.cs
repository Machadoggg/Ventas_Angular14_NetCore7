using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas.API.Utilidad;
using Ventas.BusinessLogicLayer;
using Ventas.BusinessLogicLayer.Ventas;
using Ventas.Domain.Ventas;

namespace Ventas.API.Controllers.Ventas
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaManager _ventaManager;
        private readonly IMapper _mapper;

        public VentaController(IVentaManager ventaManager, IMapper mapper)
        {
            _ventaManager = ventaManager;
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
                var ventaCreada = await _ventaManager.Registrar(modelo);
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
                var resultado = await _ventaManager.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin).ConfigureAwait(false);
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
        public async Task<IActionResult> Reporte(string fechaInicio, string fechaFin)
        {
            var respuesta = new Response<List<ReporteDTO>>();


            try
            {
                respuesta.Value = await _ventaManager.Reporte(fechaInicio, fechaFin);
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
