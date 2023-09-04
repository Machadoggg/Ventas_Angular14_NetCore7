using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas.API.Utilidad;
using Ventas.BusinessLogicLayer;
using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.Model;

namespace Ventas.API.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager _usuarioManager;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioManager usuarioServicio, IMapper mapper)
        {
            _usuarioManager = usuarioServicio;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respuesta = new Response<List<UsuarioDTO>>();

            try
            {
                var resultado = await _usuarioManager.Lista().ConfigureAwait(false);
                respuesta.Value = _mapper.Map<List<UsuarioDTO>>(resultado);
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
                respuesta.Value = await _usuarioManager.ValidarCredenciales(login.Correo, login.Clave);
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
                var modelo = _mapper.Map<Usuario>(usuario);
                var usuarioCreado = await _usuarioManager.Crear(modelo);
                respuesta.Value = _mapper.Map<UsuarioDTO>(usuarioCreado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(400, respuesta);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO usuario)
        {
            var respuesta = new Response<bool>();

            try
            {
                var modelo = _mapper.Map<Usuario>(usuario);
                respuesta.Value = await _usuarioManager.Editar(modelo);
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
                respuesta.Value = await _usuarioManager.Eliminar(id);
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
