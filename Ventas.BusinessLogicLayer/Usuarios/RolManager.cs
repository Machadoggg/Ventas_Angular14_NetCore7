using Ventas.Domain.Usuarios;


namespace Ventas.BusinessLogicLayer.Usuarios
{
    public class RolManager : IRolManager
    {
        private readonly IRolRepository _rolRepositorio;

        public RolManager(IRolRepository rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
        }

        public async Task<List<Rol>> Lista()
        {
                var listaRoles = await _rolRepositorio.ListaRolesAsync();
                return listaRoles;
        }
    }
}
