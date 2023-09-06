using Ventas.DataAccessLayer.Repositorios.Contrato;
using Ventas.Domain.Usuarios;


namespace Ventas.BusinessLogicLayer.Usuarios
{
    public class RolManager : IRolManager
    {
        private readonly IGenericRepository<Rol> _rolRepositorio;

        public RolManager(IGenericRepository<Rol> rolRepositorio)
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
