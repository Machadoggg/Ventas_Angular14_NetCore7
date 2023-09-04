using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas.API.Utilidad;
using Ventas.BusinessLogicLayer.ProductoServices;
using Ventas.DTO;

namespace Ventas.API.Controllers.Productos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaServicio;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaServicio, IMapper mapper)
        {
            _categoriaServicio = categoriaServicio;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<CategoriaDTO>>();

            try
            {
                var resultado = await _categoriaServicio.Lista().ConfigureAwait(false);
                respuesta.Value = _mapper.Map<List<CategoriaDTO>>(resultado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(404, respuesta);
            }
        }
    }
}
