using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Usuarios;
using BLL = Ventas.BusinessLogicLayer.Sesion;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {

        Task<List<Usuario>> ListaUsuariosAsync();

        Task<BLL.Sesion> ValidarCredencialesAsync(string correo, string clave);

        Task<Usuario> CrearUsuarioAsync(Usuario modelo);

        Task<bool> EditarUsuarioAsync(Usuario modelo);

        Task<bool> EliminarUsuarioAsync(int id);
    }
}
