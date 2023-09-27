using Ventas.BusinessLogicLayer.Ventas;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios.Comun;
using Ventas.Domain.Productos;
using Ventas.Domain.Ventas;

namespace Ventas.DataAccessLayer.Repositorios.Ventas
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly VentasAngular14Context _dbcontext;

        public VentaRepository(VentasAngular14Context dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            ////////////////////////TRANSACTION///////////////////
            using (var trasction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    //resta el STOCK de cada producto que esta involucrado dentro del detalle de la venta
                    foreach (DetalleVenta detalleVenta in modelo.DetalleVenta)
                    {
                        Producto productoEncontrado = _dbcontext.Productos.Where(p => p.Id == detalleVenta.IdProducto).First();

                        productoEncontrado.Stock = productoEncontrado.Stock - detalleVenta.Cantidad;
                        _dbcontext.Productos.Update(productoEncontrado);
                    }
                    await _dbcontext.SaveChangesAsync();

                    NumeroDocumento correlativo = _dbcontext.NumeroDocumentos.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbcontext.NumeroDocumentos.Update(correlativo);
                    await _dbcontext.SaveChangesAsync();

                    //Generar formato digitos (0000)
                    int cantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", cantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();//se crea (00001)

                    //obtine los 4 ultimos digitos de atras hacia adelante
                    //y define donde empieza numeroVenta.Length - cantidadDigitos = (0_0001)
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantidadDigitos);

                    modelo.NumeroDocumento = numeroVenta;

                    await _dbcontext.Venta.AddAsync(modelo);
                    await _dbcontext.SaveChangesAsync();

                    ventaGenerada = modelo;

                    trasction.Commit();

                }
                catch (Exception)
                {
                    trasction.Rollback();
                    throw;
                }
                return ventaGenerada;
            }
        }
    }
}
