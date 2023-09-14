using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Menus;
using Ventas.Domain.Usuarios;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        public Task<List<Menu>> ObtenerMenuPorIdAsync(int id);

        Task<List<Usuario>> ListaUsuariosAsync();

        Task<SesionDTO> ValidarCredencialesAsync(string correo, string clave);

        Task<Usuario> CrearUsuarioAsync(Usuario modelo);

        Task<bool> EditarUsuarioAsync(Usuario modelo);

        Task<bool> EliminarUsuarioAsync(int id);
    }
}
