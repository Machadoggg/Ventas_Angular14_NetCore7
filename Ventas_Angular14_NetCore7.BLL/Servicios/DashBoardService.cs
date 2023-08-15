using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DAL.Repositorios.Contrato;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.Model;

namespace Ventas_Angular14_NetCore7.BLL.Servicios
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IGenericRepository<Producto> _productoRepositorio;
        private readonly IMapper _mapper;

        public DashBoardService(IVentaRepository ventaRepository, IGenericRepository<Producto> productoRepositorio, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        //Metodo
        //devolver un rango de ventas de acuerdo a las fechas
        //apartir de hoy se define cuantos dias retrocede para la consulta
        private IQueryable<Venta> RetornarVentas(IQueryable<Venta> tablaVenta, int restarCantidadDias)
        { 
            DateTime? ultimaFecha = tablaVenta.OrderByDescending(v => v.FechaRegistro).Select(v => v.FechaRegistro).First();

            ultimaFecha = ultimaFecha.Value.AddDays(restarCantidadDias);

            return tablaVenta.Where(v => v.FechaRegistro.Value.Date >= ultimaFecha.Value.Date);
        }

        private async Task<int> TotalVentasUltimaSemana()
        { 
            int total = 0;
            IQueryable<Venta> _ventaQuery = await _ventaRepository.Consultar();

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
            IQueryable<Venta> _ventaQuery = await _ventaRepository.Consultar();

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = RetornarVentas(_ventaQuery, -7);

                resultado = tablaVenta.Select(v => v.Total).Sum(v => v.Value);
            }

            return Convert.ToString(resultado, new CultureInfo("es-CO"));
        }


        private async Task<int> TotalProductos()
        { 
            IQueryable<Producto> _productoQuery = await _productoRepositorio.Consultar();

            int total = _productoQuery.Count();
            return total;
        }


        private async Task<Dictionary<string, int>> VentasUltimaSemana()
        { 
            Dictionary<string, int> resultado = new Dictionary<string, int>();

            IQueryable<Venta> _ventaQuery = await _ventaRepository.Consultar();

            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = RetornarVentas(_ventaQuery, -7);

                resultado = tablaVenta
                    .GroupBy(v => v.FechaRegistro.Value.Date).OrderBy(g => g.Key)
                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"),total = dv.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
            }

            return resultado;
        }

        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO viewModelDashBoard = new DashBoardDTO();

            try
            {
                viewModelDashBoard.TotalVentas = await TotalVentasUltimaSemana();
                viewModelDashBoard.TotalIngresos = await TotalIngresosUltimaSemana();
                viewModelDashBoard.TotalProductos = await TotalProductos();

                List<VentasSemanaDTO> listaVentaSemana = new List<VentasSemanaDTO>();

                foreach (KeyValuePair<string, int> item in await VentasUltimaSemana())
                {
                    listaVentaSemana.Add(new VentasSemanaDTO()
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
