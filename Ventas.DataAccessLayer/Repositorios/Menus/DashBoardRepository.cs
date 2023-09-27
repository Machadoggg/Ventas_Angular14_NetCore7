using System.Globalization;
using Ventas.BusinessLogicLayer;
using Ventas.BusinessLogicLayer.Menus;
using Ventas.BusinessLogicLayer.Productos;
using Ventas.BusinessLogicLayer.Ventas;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios.Comun;
using Ventas.Domain.Productos;
using Ventas.Domain.Ventas;

namespace Ventas.DataAccessLayer.Repositorios.Menus
{
    public class DashBoardRepository : GenericRepository<DashBoard>, IDashBoardRepository
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoRepository _productoRepositorio;

        public DashBoardRepository(VentasAngular14Context dbContext, IVentaRepository ventaRepository, IProductoRepository productoRepositorio) : base(dbContext)
        {
            _ventaRepository = ventaRepository;
            _productoRepositorio = productoRepositorio;
        }

        //devolver un rango de ventas de acuerdo a fechas
        //apartir de hoy se define cuantos dias retrocede para la consulta
        private IQueryable<Venta> RetornarVentas(IQueryable<Venta> tablaVenta, int restarCantidadDias)
        {
            DateTime? ultimaFecha = tablaVenta.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();

            ultimaFecha = ultimaFecha.Value.AddDays(restarCantidadDias);

            return tablaVenta.Where(v => v.FechaRegistro.Date >= ultimaFecha.Value.Date);
        }

        private async Task<int> TotalVentasUltimaSemana()
        {
            int total = 0;
            IQueryable<Venta> _ventaQuery = _ventaRepository.Consultar();

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = RetornarVentas(_ventaQuery, -7);
                total = tablaVenta.Count();
            }

            return total;
        }

        private async Task<string> TotalIngresosUltimaSemana()
        {
            decimal resultado = 0;
            IQueryable<Venta> _ventaQuery = _ventaRepository.Consultar();

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = RetornarVentas(_ventaQuery, -7);

                resultado = tablaVenta.Select(v => v.Total).Sum(v => v);
            }

            return Convert.ToString(resultado, new CultureInfo("es-CO"));
        }


        private async Task<int> TotalProductos()
        {
            IQueryable<Producto> _productoQuery = _productoRepositorio.Consultar();

            int total = _productoQuery.Count();
            return total;
        }


        private async Task<Dictionary<string, int>> VentasUltimaSemana()
        {
            Dictionary<string, int> resultado = new Dictionary<string, int>();

            IQueryable<Venta> _ventaQuery = _ventaRepository.Consultar();

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = RetornarVentas(_ventaQuery, -7);

                resultado = tablaVenta
                    .GroupBy(v => v.FechaRegistro.Date).OrderBy(g => g.Key)
                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
            }

            return resultado;
        }

        public async Task<DashBoard> ResumenAsync()
        {
            DashBoard viewModelDashBoard = new DashBoard();

            try
            {
                viewModelDashBoard.TotalVentas = await TotalVentasUltimaSemana();
                viewModelDashBoard.TotalIngresos = await TotalIngresosUltimaSemana();
                viewModelDashBoard.TotalProductos = await TotalProductos();

                List<VentasSemana> listaVentaSemana = new List<VentasSemana>();

                foreach (KeyValuePair<string, int> item in await VentasUltimaSemana())
                {
                    listaVentaSemana.Add(new VentasSemana()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }

                viewModelDashBoard.VentasUltimaSemana = listaVentaSemana;
            }
            catch (Exception)
            {
                throw;
            }

            return viewModelDashBoard;
        }
    }
}
