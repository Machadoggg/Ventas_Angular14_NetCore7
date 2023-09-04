using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas.API.Utilidad;
using Ventas.BusinessLogicLayer;
using Ventas.BusinessLogicLayer.Menus;

namespace Ventas.API.Controllers.Menus
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardManager _dashBoardManager;
        private readonly IMapper _mapper;

        public DashBoardController(IDashBoardManager dashBoardManager, IMapper mapper)
        {
            _dashBoardManager = dashBoardManager;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            var respuesta = new Response<DashBoardDTO>();

            try
            {
                var resultado = await _dashBoardManager.Resumen().ConfigureAwait(false);
                respuesta.Value = _mapper.Map<DashBoardDTO>(resultado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(400, respuesta);
            }
        }
    }
}
