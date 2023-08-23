using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DAL.Repositorios.Contrato;
using Ventas_Angular14_NetCore7.Model;

namespace Ventas_Angular14_NetCore7.BLL.Servicios
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
