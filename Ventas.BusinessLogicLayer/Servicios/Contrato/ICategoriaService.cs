using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Servicios.Contrato
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> Lista();
    }
}
