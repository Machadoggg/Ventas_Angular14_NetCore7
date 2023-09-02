using Ventas_Angular14_NetCore7.Model;

namespace Ventas_Angular14_NetCore7.DAL.Repositorios.Contrato
{
    //Aqui especificamos que vamos a trabajar con el
    //modelo de (Venta) en especifico (IGenericRepository<Venta>)
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Registrar(Venta modelo);
    }
}
