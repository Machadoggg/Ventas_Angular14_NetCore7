using Ventas.Model;

namespace Ventas.BLL.Servicios.Contrato
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> Lista();
    }
}
