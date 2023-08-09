using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.API.Utilidad;

namespace Ventas_Angular14_NetCore7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuServicio;

        public MenuController(IMenuService menuServicio)
        {
            _menuServicio = menuServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista(int idUsuario)
        {
            var respuesta = new Response<List<MenuDTO>>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _menuServicio.Lista(idUsuario);
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
