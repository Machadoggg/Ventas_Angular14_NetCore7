using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas_Angular14_NetCore7.API.Utilidad;
using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;

namespace Ventas_Angular14_NetCore7.API.Controllers.Productos
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
                respuesta.Ok = true;
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
