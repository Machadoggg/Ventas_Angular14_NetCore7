using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Servicios.Contrato
{
    public interface IMenuService
    {
        Task<List<Menu>> Lista(int idUsuario);
    }
}