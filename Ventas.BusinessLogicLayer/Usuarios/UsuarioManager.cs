using Ventas.Domain.Usuarios;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioRepository _usuarioRepositorio;

        public UsuarioManager(IUsuarioRepository usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
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
            var usuarioEditado = await _usuarioRepositorio.EditarUsuarioAsync(modelo).ConfigureAwait(false);
            return usuarioEditado;
        }

        public async Task<bool> Eliminar(int id)
        {
            var usuarioEliminado = await _usuarioRepositorio.EliminarUsuarioAsync(id).ConfigureAwait(false);
            return usuarioEliminado;
        }
    }
}
