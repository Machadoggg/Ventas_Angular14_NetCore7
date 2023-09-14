using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer;
using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.DataAccessLayer.DBContext;
using Ventas.Domain.Menus;
using Ventas.Domain.Usuarios;
using AutoMapper;

namespace Ventas.DataAccessLayer.Repositorios
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly VentasAngular14Context _dbContext;
        private readonly IMapper _mapper;

        public UsuarioRepository(VentasAngular14Context dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<List<Menu>> ObtenerMenuPorIdAsync(int id)
        {
            try
            {
                var listaMenus = await (from u in _dbContext.Usuarios
                                        join mr in _dbContext.MenuRols on u.IdRol equals mr.IdRol
                                        join m in _dbContext.Menus on mr.IdMenu equals m.Id
                                        where u.Id == id
                                        select m).ToListAsync();
                return listaMenus;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Usuario>> ListaUsuariosAsync()
        {
            try
            {
                var queryUsuario = _dbContext.Usuarios;
                var listaUsuarios = await queryUsuario.Include(rol => rol.IdRolNavigation).ToListAsync();

                return listaUsuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SesionDTO> ValidarCredencialesAsync(string correo, string clave)
        {
            try
            {
                var queryUsuario = await _dbContext.Usuarios
                .Include(rol => rol.IdRolNavigation)
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Clave == clave);
                
                if (queryUsuario == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }

                return _mapper.Map<SesionDTO>(queryUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
