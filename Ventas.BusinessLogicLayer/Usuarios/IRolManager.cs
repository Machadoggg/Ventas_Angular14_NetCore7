using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public interface IRolManager
    {
        Task<List<Rol>> Lista();
    }
}
