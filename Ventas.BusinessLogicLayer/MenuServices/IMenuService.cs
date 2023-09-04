using Ventas.Model;

namespace Ventas.BusinessLogicLayer.MenuServices
{
    public interface IMenuService
    {
        Task<List<Menu>> Lista(int idUsuario);
    }
}