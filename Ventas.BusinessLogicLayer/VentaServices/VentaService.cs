using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Ventas.DataAccessLayer.Repositorios.Contrato;
using Ventas.Model;

namespace Ventas.BusinessLogicLayer.VentaServices
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IGenericRepository<DetalleVenta> _detalleVentaRepositorio;
        private readonly IMapper _mapper;

        public VentaService(IVentaRepository ventaRepository, IGenericRepository<DetalleVenta> detalleVentaRepositorio, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _detalleVentaRepositorio = detalleVentaRepositorio;
            _mapper = mapper;
        }


        public async Task<Venta> Registrar(Venta modelo)
        {
            try
            {
                var ventaGenerada = await _ventaRepository.Registrar(_mapper.Map<Venta>(modelo));

                if (ventaGenerada.IdVenta == 0)
                    throw new Exception("No se pudo crear");

                return ventaGenerada;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Venta>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            IQueryable<Venta> query = await _ventaRepository.Consultar();
            var listaResultado = new List<Venta>();

            try
            {
                if (buscarPor == "fecha")
                {
                    DateTime fecha_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-CO"));
                    DateTime fecha_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-CO"));

                    listaResultado = await query.Where(v =>
                        v.FechaRegistro.Value.Date >= fecha_Inicio &&
                        v.FechaRegistro.Value.Date <= fecha_Fin.Date
                    ).Include(dv => dv.DetalleVenta)
                    .ThenInclude(p => p.IdProductoNavigation)
                    .ToListAsync();


                }
                else
                {
                    listaResultado = await query.Where(v =>
                        v.NumeroDocumento == numeroVenta
                    ).Include(dv => dv.DetalleVenta)
                    .ThenInclude(p => p.IdProductoNavigation)
                    .ToListAsync();
                }
                return listaResultado;
            }
            catch (Exception)
            {
                throw;
            }


        }


        public async Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin)
        {
            IQueryable<DetalleVenta> query = await _detalleVentaRepositorio.Consultar();
            var listaResultado = new List<DetalleVenta>();

            try
            {
                DateTime fecha_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-CO"));
                DateTime fecha_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-CO"));

                listaResultado = await query
                    .Include(p => p.IdProductoNavigation)
                    .Include(v => v.IdVentaNavigation)
                    .Where(dv =>
                           dv.IdVentaNavigation.FechaRegistro.Value.Date >= fecha_Inicio.Date &&
                           dv.IdVentaNavigation.FechaRegistro.Value.Date <= fecha_Fin.Date
                        ).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<List<ReporteDTO>>(listaResultado);
        }
    }
}
