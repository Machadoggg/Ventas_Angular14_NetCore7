using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer;
using Ventas.BusinessLogicLayer.Comun;
using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios.Comun;
using Ventas.Domain.Usuarios;

namespace Ventas.DataAccessLayer.Repositorios.Usuarios
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly VentasAngular14Context _dbContext;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _genericRepositorio;

        public UsuarioRepository(VentasAngular14Context dbContext, IMapper mapper, IGenericRepository<Usuario> usuarioRepositorio) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _genericRepositorio = usuarioRepositorio;
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

        public async Task<Usuario> CrearUsuarioAsync(Usuario modelo)
        {
            try
            {
                var usuarioCreado = await _genericRepositorio.Crear(modelo);

                if (usuarioCreado.Id == 0)
                    throw new Exception("No se pudo crear el usuario");

                var queryUsuario = await _genericRepositorio.Consultar(u => u.Id == usuarioCreado.Id);
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
                var usuarioEncontrado = await _genericRepositorio.Obtener(u => u.Id == modelo.Id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                usuarioEncontrado.NombreCompleto = modelo.NombreCompleto;
                usuarioEncontrado.Correo = modelo.Correo;
                usuarioEncontrado.IdRol = modelo.IdRol;
                usuarioEncontrado.Clave = modelo.Clave;
                usuarioEncontrado.EsActivo = modelo.EsActivo;

                bool respuesta = await _genericRepositorio.Editar(usuarioEncontrado);

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
                var usuarioEncontrado = await _genericRepositorio.Obtener(u => u.Id == id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool respuesta = await _genericRepositorio.Eliminar(usuarioEncontrado);

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
