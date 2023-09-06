using Ventas.Domain.Ventas;

namespace Ventas.DataAccessLayer.Repositorios.Contrato
{
    //Aqui especificamos que vamos a trabajar con el
    //modelo de (Venta) en especifico (IGenericRepository<Venta>)
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}
