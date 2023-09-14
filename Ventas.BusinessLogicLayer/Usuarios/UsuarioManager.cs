using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Usuarios;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioRepository _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioManager(IUsuarioRepository usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }


        public async Task<List<Usuario>> Lista()
        {
            var listaUsuarios = await _usuarioRepositorio.ListaUsuariosAsync().ConfigureAwait(false);
            return listaUsuarios;
        }

        public async Task<SesionDTO> ValidarCredenciales(string correo, string clave)
        {
            var validarUsuario = await _usuarioRepositorio.ValidarCredencialesAsync(correo, clave).ConfigureAwait(false);
            return validarUsuario;
            
        }

        public async Task<Usuario> Crear(Usuario modelo)
        {
            var usuarioCreado = await _usuarioRepositorio.CrearUsuarioAsync(modelo).ConfigureAwait(false);
            return usuarioCreado;
        }









        public async Task<bool> Editar(Usuario modelo)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.Id == modelo.Id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                usuarioEncontrado.NombreCompleto = modelo.NombreCompleto;
                usuarioEncontrado.Correo = modelo.Correo;
                usuarioEncontrado.IdRol = modelo.IdRol;
                usuarioEncontrado.Clave = modelo.Clave;
                usuarioEncontrado.EsActivo = modelo.EsActivo;

                bool respuesta = await _usuarioRepositorio.Editar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.Id == id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool respuesta = await _usuarioRepositorio.Eliminar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
