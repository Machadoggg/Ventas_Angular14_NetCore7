using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas_Angular14_NetCore7.API.Utilidad;
using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;

namespace Ventas_Angular14_NetCore7.API.Controllers.Menus
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuServicio;
        private readonly IMapper _mapper;

        public MenuController(IMenuService menuServicio, IMapper mapper)
        {
            _menuServicio = menuServicio;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idUsuario)
        {
            var respuesta = new Response<List<MenuDTO>>();

            try
            {
                var resultado = await _menuServicio.Lista(idUsuario).ConfigureAwait(false);
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
