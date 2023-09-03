using Ventas.Model;

namespace Ventas.BLL.Servicios.Contrato
{
    public interface IRolService
    {
        Task<List<Rol>> Lista();
    }
}
