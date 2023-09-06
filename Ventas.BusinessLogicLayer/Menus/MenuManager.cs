using Ventas.DataAccessLayer.Repositorios.Contrato;
using Ventas.Domain.Menus;
using Ventas.Domain.Usuarios;

namespace Ventas.BusinessLogicLayer.Menus
{
    public class MenuManager : IMenuManager
    {
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;
        private readonly IGenericRepository<MenuRol> _menuRolRepositorio;
        private readonly IGenericRepository<Menu> _menuRepositorio;

        public MenuManager(IGenericRepository<Usuario> usuarioRepositorio,
            IGenericRepository<MenuRol> menuRolRepositorio,
            IGenericRepository<Menu> menuRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _menuRolRepositorio = menuRolRepositorio;
            _menuRepositorio = menuRepositorio;
        }

        public async Task<List<Menu>> Lista(int idUsuario)
        {
            IQueryable<Usuario> tablaUsuario = await _usuarioRepositorio.Consultar(u => u.Id == idUsuario);
            IQueryable<MenuRol> tablaMenuRol = await _menuRolRepositorio.Consultar();
            IQueryable<Menu> tablaMenu = await _menuRepositorio.Consultar();

            //obtener los menus de acuerdo a el tipo de usuario en base a (idUsuario)
            try
            {
                IQueryable<Menu> tablaResultado = (from u in tablaUsuario
                                                   join mr in tablaMenuRol on u.IdRol equals mr.IdRol
                                                   join m in tablaMenu on mr.IdMenu equals m.Id
                                                   select m).AsQueryable();

                var listaMenus = tablaResultado.ToList();
                return listaMenus;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}