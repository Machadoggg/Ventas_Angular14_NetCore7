using Ventas.Domain.Usuarios;
using BLL = Ventas.BusinessLogicLayer.Sesion;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public interface IUsuarioManager
    {
        Task<List<Usuario>> Lista();

        Task<BLL.Sesion> ValidarCredenciales(string correo, string clave);

        Task<Usuario> Crear(Usuario modelo);

        Task<bool> Editar(Usuario modelo);

        Task<bool> Eliminar(int id);
    }
}
