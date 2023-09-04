using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas.API.Utilidad;
using Ventas.BusinessLogicLayer.Usuarios;

namespace Ventas.API.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolManager _rolManager;
        private readonly IMapper _mapper;

        public RolController(IRolManager rolManager, IMapper mapper)
        {
            _rolManager = rolManager;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<RolDTO>>();

            try
            {
                var resultado = await _rolManager.Lista().ConfigureAwait(false);
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
