using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.API.Utilidad;

namespace Ventas_Angular14_NetCore7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaServicio;

        public CategoriaController(ICategoriaService categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<CategoriaDTO>>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _categoriaServicio.Lista();
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
