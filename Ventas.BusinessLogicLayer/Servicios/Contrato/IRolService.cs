using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Servicios.Contrato
{
    public interface IRolService
    {
        Task<List<Rol>> Lista();
    }
}
