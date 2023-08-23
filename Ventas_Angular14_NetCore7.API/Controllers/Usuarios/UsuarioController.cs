using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.API.Utilidad;
using Ventas_Angular14_NetCore7.Model;

namespace Ventas_Angular14_NetCore7.API.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioServicio;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioServicio, IMapper mapper)
        {
            _usuarioServicio = usuarioServicio;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<UsuarioDTO>>();

            try
            {
                var resultado = await _usuarioServicio.Lista().ConfigureAwait(false);
                respuesta.Value = _mapper.Map<List<UsuarioDTO>>(resultado);
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

        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO login)
        {
            var respuesta = new Response<SesionDTO>();

            try
            {
                respuesta.Ok = true;
                respuesta.Value = await _usuarioServicio.ValidarCredenciales(login.Correo, login.Clave);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
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
                respuesta.Ok = true;
                respuesta.Value = await _usuarioServicio.Crear(usuario);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
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
                var modelo = _mapper.Map<Usuario>(usuario);
                respuesta.Ok = true;
                respuesta.Value = await _usuarioServicio.Editar(modelo);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(400, respuesta);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Response<bool>();

            try
            {
                respuesta.Ok = true;
                respuesta.Value = await _usuarioServicio.Eliminar(id);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
