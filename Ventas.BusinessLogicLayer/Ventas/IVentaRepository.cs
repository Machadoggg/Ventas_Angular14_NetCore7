using Ventas.BusinessLogicLayer.Comun;
using Ventas.Domain.Ventas;

namespace Ventas.BusinessLogicLayer.Ventas
{
    //Aqui especificamos que vamos a trabajar con el
    //modelo de (Venta) en especifico (IGenericRepository<Venta>)
    public interface IVentaRepository : IProductoRepository<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}
