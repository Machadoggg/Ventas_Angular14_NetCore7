using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.API.Utilidad;

namespace Ventas_Angular14_NetCore7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioServicio;

        public UsuarioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<UsuarioDTO>>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _usuarioServicio.Lista();
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.MsgError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO login)
        {
            var respuesta = new Response<SesionDTO>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _usuarioServicio.ValidarCredenciales(login.Correo, login.Clave);
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.MsgError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO usuario)
        {
            var respuesta = new Response<UsuarioDTO>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _usuarioServicio.Crear(usuario);
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.MsgError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO usuario)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _usuarioServicio.Editar(usuario);
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.MsgError = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.Status = true;
                respuesta.Value = await _usuarioServicio.Eliminar(id);
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
