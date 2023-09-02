using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas_Angular14_NetCore7.API.Utilidad;
using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.Model;

namespace Ventas_Angular14_NetCore7.API.Controllers.Productos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoServicio;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoServicio = productoService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<ProductoDTO>>();

            try
            {
                var resultado = await _productoServicio.Lista().ConfigureAwait(false);
                respuesta.Value = _mapper.Map<List<ProductoDTO>>(resultado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(500, respuesta);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ProductoDTO producto)
        {
            var respuesta = new Response<ProductoDTO>();

            try
            {
                var modelo = _mapper.Map<Producto>(producto);
                var productoCreado = await _productoServicio.Crear(modelo);
                respuesta.Value = _mapper.Map<ProductoDTO>(productoCreado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(500, respuesta);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO producto)
        {
            var respuesta = new Response<bool>();

            try
            {
                var modelo = _mapper.Map<Producto>(producto);
                respuesta.Value = await _productoServicio.Editar(modelo);
                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(500, respuesta);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.Value = await _productoServicio.Eliminar(id);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(500, respuesta);
            }
        }
    }
}
