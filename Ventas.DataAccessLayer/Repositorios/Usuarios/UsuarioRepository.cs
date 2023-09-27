using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Sesion;
using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios.Comun;
using Ventas.Domain.Usuarios;

namespace Ventas.DataAccessLayer.Repositorios.Usuarios
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly IMapper _mapper;

        public UsuarioRepository(VentasAngular14Context dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }


        public async Task<List<Usuario>> ListaUsuariosAsync()
        {
            try
            {
                var queryUsuario = Consultar();
                var listaUsuarios = await queryUsuario.Include(rol => rol.IdRolNavigation).ToListAsync();
                return listaUsuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sesion> ValidarCredencialesAsync(string correo, string clave)
        {
            try
            {
                var queryUsuario = Consultar();
                var usuario = await queryUsuario
                    .Include(rol => rol.IdRolNavigation)
                    .FirstOrDefaultAsync(u => u.Correo == correo && u.Clave == clave);

                if (usuario == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }

                return _mapper.Map<Sesion>(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario modelo)
        {
            try
            {
                var usuarioCreado = await CrearAsync(modelo);

                if (usuarioCreado.Id == 0)
                    throw new Exception("No se pudo crear el usuario");

                var queryUsuario = Consultar(u => u.Id == usuarioCreado.Id);
                usuarioCreado = queryUsuario.Include(rol => rol.IdRolNavigation).First();

                return usuarioCreado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EditarUsuarioAsync(Usuario modelo)
        {
            try
            {
                var usuarioEncontrado = await ObtenerAsync(u => u.Id == modelo.Id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                usuarioEncontrado.NombreCompleto = modelo.NombreCompleto;
                usuarioEncontrado.Correo = modelo.Correo;
                usuarioEncontrado.IdRol = modelo.IdRol;
                usuarioEncontrado.Clave = modelo.Clave;
                usuarioEncontrado.EsActivo = modelo.EsActivo;

                bool respuesta = await EditarAsync(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            try
            {
                var usuarioEncontrado = await ObtenerAsync(u => u.Id == id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool respuesta = await Eliminar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
