using Ventas.Domain.Usuarios;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public interface IRolManager
    {
        Task<List<Rol>> Lista();
    }
}
