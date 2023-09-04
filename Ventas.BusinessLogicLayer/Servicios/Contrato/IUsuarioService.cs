using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> Lista();
        Task<SesionDTO> ValidarCredenciales(string correo, string clave);
        Task<Usuario> Crear(Usuario modelo);
        Task<bool> Editar(Usuario modelo);
        Task<bool> Eliminar(int id);
    }
}
