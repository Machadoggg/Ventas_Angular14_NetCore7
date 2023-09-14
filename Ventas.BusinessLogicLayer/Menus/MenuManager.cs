using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.Domain.Menus;

namespace Ventas.BusinessLogicLayer.Menus
{
    public class MenuManager : IMenuManager
    {
        private readonly IMenuRepository _menuRepositorio;

        public MenuManager(IMenuRepository menuRepositorio)
        {
            _menuRepositorio = menuRepositorio;
        }


        public async Task<List<Menu>> Lista(int idUsuario)
        {
            return await _menuRepositorio.ObtenerMenuPorIdAsync(idUsuario).ConfigureAwait(false);
        }
    }
}