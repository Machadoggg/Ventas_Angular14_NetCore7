using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public interface IUsuarioManager
    {
        Task<List<Usuario>> Lista();
        Task<SesionDTO> ValidarCredenciales(string correo, string clave);
        Task<Usuario> Crear(Usuario modelo);
        Task<bool> Editar(Usuario modelo);
        Task<bool> Eliminar(int id);
    }
}
