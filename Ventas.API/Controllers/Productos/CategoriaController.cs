using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas.API.Utilidad;
using Ventas.BusinessLogicLayer.Productos;
using Ventas.DTO;

namespace Ventas.API.Controllers.Productos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaManager _categoriaManager;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaManager categoriaServicio, IMapper mapper)
        {
            _categoriaManager = categoriaServicio;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<CategoriaDTO>>();

            try
            {
                var resultado = await _categoriaManager.Lista().ConfigureAwait(false);
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
