using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Comun;
using Ventas.BusinessLogicLayer.Productos;
using Ventas.DataAccessLayer.DBContext;
using Ventas.Domain.Productos;

namespace Ventas.DataAccessLayer.Repositorios
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly VentasAngular14Context _dbContext;
        private readonly IGenericRepository<Producto> _genericRepositorio;

        public ProductoRepository(VentasAngular14Context dbContext, IGenericRepository<Producto> genericRepositorio) : base(dbContext)
        {
            _dbContext = dbContext;
            _genericRepositorio = genericRepositorio;
        }


        public async Task<List<Producto>> ListaProductosAsync()
        {
            try
            {
                var queryProducto = _dbContext.Productos;
                var listaProductos = await queryProducto.Include(cat => cat.IdCategoriaNavigation).ToListAsync();

                return listaProductos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Producto> CrearProductoAsync(Producto modelo)
        {
            try
            {
                var productoCreado = await _genericRepositorio.Crear(modelo);

                if (productoCreado.Id == 0)
                    throw new Exception("No se pudo crear el producto");

                var queryProducto = await _genericRepositorio.Consultar(u => u.Id == productoCreado.Id);
                productoCreado = queryProducto.Include(cat => cat.IdCategoriaNavigation).First();

                return productoCreado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EditarProductoAsync(Producto modelo)
        {
            try
            {
                var productoEncontrado = await _genericRepositorio.Obtener(u => u.Id == modelo.Id);

                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El producto no existe");
                }

                productoEncontrado.Nombre = modelo.Nombre;
                productoEncontrado.IdCategoria = modelo.IdCategoria;
                productoEncontrado.Stock = modelo.Stock;
                productoEncontrado.Precio = modelo.Precio;
                productoEncontrado.EsActivo = modelo.EsActivo;

                bool respuesta = await _genericRepositorio.Editar(productoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EliminarProductoAsync(int id)
        {
            try
            {
                var productoEncontrado = await _genericRepositorio.Obtener(p => p.Id == id);

                if (productoEncontrado == null)
                    throw new TaskCanceledException("El producto no existe");

                bool respuesta = await _genericRepositorio.Eliminar(productoEncontrado);

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
