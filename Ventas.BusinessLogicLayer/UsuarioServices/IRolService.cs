using Ventas.Model;

namespace Ventas.BusinessLogicLayer.UsuarioServices
{
    public interface IRolService
    {
        Task<List<Rol>> Lista();
    }
}
