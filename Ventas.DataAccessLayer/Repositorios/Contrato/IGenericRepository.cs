using System.Linq.Expressions;

namespace Ventas.DataAccessLayer.Repositorios.Contrato
{

    //Especifica que (TModel) es una clase con (where TModel : class)
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);
        Task<TModel> Crear(TModel modelo);
        Task<bool> Editar(TModel modelo);
        Task<bool> Eliminar(TModel modelo);
        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> ? filtro = null);
    }
}
