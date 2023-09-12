using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.Domain.Menus;

namespace Ventas.BusinessLogicLayer.Menus
{
    public class MenuManager : IMenuManager
    {
        private readonly IUsuarioRepository _usuarioRepositorio;

        public MenuManager(IUsuarioRepository usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public async Task<List<Menu>> Lista(int idUsuario)
        {
            return await _usuarioRepositorio.ObtenerMenuPorIdAsync(idUsuario).ConfigureAwait(false);
        }
    }
}