using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Menus
{
    public interface IMenuManager
    {
        Task<List<Menu>> Lista(int idUsuario);
    }
}