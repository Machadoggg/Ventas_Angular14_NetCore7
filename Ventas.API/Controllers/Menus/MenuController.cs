using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas.API.Utilidad;
using Ventas.BusinessLogicLayer.Menus;

namespace Ventas.API.Controllers.Menus
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuManager _menuManager;
        private readonly IMapper _mapper;

        public MenuController(IMenuManager menuManager, IMapper mapper)
        {
            _menuManager = menuManager;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idUsuario)
        {
            var respuesta = new Response<List<MenuDTO>>();

            try
            {
                var resultado = await _menuManager.Lista(idUsuario).ConfigureAwait(false);
                respuesta.Value = _mapper.Map<List<MenuDTO>>(resultado);
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
