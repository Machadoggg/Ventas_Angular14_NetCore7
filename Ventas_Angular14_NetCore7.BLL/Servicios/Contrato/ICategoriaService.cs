using Ventas_Angular14_NetCore7.Model;

namespace Ventas_Angular14_NetCore7.BLL.Servicios.Contrato
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> Lista();
    }
}
