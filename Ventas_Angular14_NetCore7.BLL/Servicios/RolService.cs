using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DAL.Repositorios.Contrato;
using Ventas_Angular14_NetCore7.Model;


namespace Ventas_Angular14_NetCore7.BLL.Servicios
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _rolRepositorio;

        public RolService(IGenericRepository<Rol> rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
        }

        public async Task<List<Rol>> Lista()
        {
            try
            {
                //Convertir (Rol) a (RolDTO) en forma de lista
                var listaRoles = await _rolRepositorio.Consultar();
                return listaRoles.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
