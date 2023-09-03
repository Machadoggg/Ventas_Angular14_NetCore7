using Ventas.Model;

namespace Ventas.BLL.Servicios.Contrato
{
    public interface IMenuService
    {
        Task<List<Menu>> Lista(int idUsuario);
    }
}