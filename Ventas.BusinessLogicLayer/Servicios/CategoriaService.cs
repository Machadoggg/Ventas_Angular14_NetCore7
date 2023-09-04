using Ventas.BusinessLogicLayer.Servicios.Contrato;
using Ventas.DAL.Repositorios.Contrato;
using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Servicios
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _categoriaRepositorio;

        public CategoriaService(IGenericRepository<Categoria> categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<Categoria>> Lista()
        {
            try
            {
                var listaCategorias = await _categoriaRepositorio.Consultar();
                return listaCategorias.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
