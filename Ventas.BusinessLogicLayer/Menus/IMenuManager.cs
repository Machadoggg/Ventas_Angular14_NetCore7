using Ventas.Domain.Menus;

namespace Ventas.BusinessLogicLayer.Menus
{
    public interface IMenuManager
    {
        Task<List<Menu>> Lista(int idUsuario);
    }
}