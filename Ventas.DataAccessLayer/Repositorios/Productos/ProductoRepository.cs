using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Productos;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios.Comun;
using Ventas.Domain.Productos;

namespace Ventas.DataAccessLayer.Repositorios.Productos
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {

        public ProductoRepository(VentasAngular14Context dbContext) : base(dbContext)
        {
        }


        public async Task<List<Producto>> ListaProductosAsync()
        {
            try
            {
                var queryProducto = Consultar();
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
                var productoCreado = await CrearAsync(modelo);

                if (productoCreado.Id == 0)
                    throw new Exception("No se pudo crear el producto");

                var queryProducto = Consultar(u => u.Id == productoCreado.Id);
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
                var productoEncontrado = await ObtenerAsync(u => u.Id == modelo.Id);

                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El producto no existe");
                }

                productoEncontrado.Nombre = modelo.Nombre;
                productoEncontrado.IdCategoria = modelo.IdCategoria;
                productoEncontrado.Stock = modelo.Stock;
                productoEncontrado.Precio = modelo.Precio;
                productoEncontrado.EsActivo = modelo.EsActivo;

                bool respuesta = await EditarAsync(productoEncontrado);

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
                var productoEncontrado = await ObtenerAsync(p => p.Id == id);

                if (productoEncontrado == null)
                    throw new TaskCanceledException("El producto no existe");

                bool respuesta = await Eliminar(productoEncontrado);

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
