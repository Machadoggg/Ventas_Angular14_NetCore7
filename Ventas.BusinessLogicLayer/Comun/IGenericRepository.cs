using System.Linq.Expressions;

namespace Ventas.BusinessLogicLayer.Comun
{

    //Especifica que (TModel) es una clase con (where TModel : class)
    public interface IProductoRepository<TModel> where TModel : class
    {
        Task<TModel> ObtenerAsync(Expression<Func<TModel, bool>> filtro);
        Task<TModel> CrearAsync(TModel modelo);
        Task<bool> EditarAsync(TModel modelo);
        Task<bool> Eliminar(TModel modelo);
        IQueryable<TModel> Consultar(Expression<Func<TModel, bool>>? filtro = null);
    }
}
