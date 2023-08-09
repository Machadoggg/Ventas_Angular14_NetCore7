using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.API.Utilidad;

namespace Ventas_Angular14_NetCore7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolServicio;

        public RolController(IRolService rolServicio)
        {
            _rolServicio = rolServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        { 
            var respuesta = new Response<List<RolDTO>>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _rolServicio.Lista();
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
