using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.API.Utilidad;

namespace Ventas_Angular14_NetCore7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoService _productoServicio;

        public ProductoController(IProductoService productoService)
        {
            _productoServicio = productoService;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<ProductoDTO>>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _productoServicio.Lista();
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.MsgError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ProductoDTO producto)
        {
            var respuesta = new Response<ProductoDTO>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _productoServicio.Crear(producto);
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.MsgError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO producto)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _productoServicio.Editar(producto);
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.MsgError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _productoServicio.Eliminar(id);
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.MsgError = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
