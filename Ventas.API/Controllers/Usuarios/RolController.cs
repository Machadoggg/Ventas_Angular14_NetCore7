using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas.API.Utilidad;
using Ventas.BusinessLogicLayer.UsuarioServices;

namespace Ventas.API.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolServicio;
        private readonly IMapper _mapper;

        public RolController(IRolService rolServicio, IMapper mapper)
        {
            _rolServicio = rolServicio;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<RolDTO>>();

            try
            {
                var resultado = await _rolServicio.Lista().ConfigureAwait(false);
                respuesta.Value = _mapper.Map<List<RolDTO>>(resultado);
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
