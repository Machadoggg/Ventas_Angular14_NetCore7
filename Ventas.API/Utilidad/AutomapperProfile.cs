using AutoMapper;
using System.Globalization;
using Ventas.API.Controllers.Menus;
using Ventas.API.Controllers.Productos;
using Ventas.API.Controllers.Usuarios;
using Ventas.API.Controllers.Ventas;
using Ventas.BusinessLogicLayer;
using Ventas.DTO;
using Ventas.Model;

namespace Ventas.API.Utilidad
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            #region Rol
            //mapeo en 2 direcciones
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion Menu

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.RolDescripcion,
                    opt => opt.MapFrom(origen => origen.IdRolNavigation!.Nombre)
                 )
                .ForMember(destino =>
                    destino.EsActivo,
                    opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                 );

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino =>
                    destino.IdRolNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(destino =>
                    destino.EsActivo,
                    opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                 );


            CreateMap<Usuario, SesionDTO>()
                .ForMember(destino =>
                    destino.RolDescripcion,
                    opt => opt.MapFrom(origen => origen.IdRolNavigation.Nombre)
                 );

            #endregion Usuario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            #endregion Categoria

            #region Producto

            CreateMap<Producto, ProductoDTO>()
                .ForMember(destino =>
                    destino.DescripcionCategoria,
                    opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Nombre)
                 )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.ToString(), new CultureInfo("es-CO")))
                 )
                .ForMember(destino =>
                    destino.EsActivo,
                    opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                 );

            CreateMap<ProductoDTO, Producto>()
                .ForMember(destino =>
                    destino.IdCategoriaNavigation,
                    opt => opt.Ignore()
                 )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-CO")))
                 )
                .ForMember(destino =>
                    destino.EsActivo,
                    opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                 );
            #endregion Producto

            #region Venta
            CreateMap<Venta, VentaDTO>()
                .ForMember(destino =>
                    destino.TotalTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.ToString(), new CultureInfo("es-CO")))
                 )
                .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.FechaRegistro.ToString("dd/MM/yyyy"))
                 );

            CreateMap<VentaDTO, Venta>()
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-CO")))
                 );
            #endregion Venta

            #region DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>()
                .ForMember(destino =>
                    destino.DescripcionProducto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                 )
                .ForMember(destino =>
                    destino.PrecioTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.ToString(), new CultureInfo("es-CO")))
                 )
                .ForMember(destino =>
                    destino.TotalTexto,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.ToString(), new CultureInfo("es-CO")))
                 );

            CreateMap<DetalleVentaDTO, DetalleVenta>()
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-CO")))
                 )
                 .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-CO")))
                 );
            #endregion DetalleVenta

            #region Reporte
            //mapeo en 2 direcciones
            CreateMap<DetalleVenta, ReporteDTO>()
                .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.FechaRegistro.ToString("dd/MM/yyyy"))
                 )
                .ForMember(destino =>
                    destino.NumeroDocumento,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.NumeroDocumento)
                 )
                .ForMember(destino =>
                    destino.TipoPago,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.TipoPago)
                 )
                .ForMember(destino =>
                    destino.TotalVenta,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.Total, new CultureInfo("es-CO")))
                 )
                .ForMember(destino =>
                    destino.Producto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                 )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.ToString(), new CultureInfo("es-CO")))
                 )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.ToString(), new CultureInfo("es-CO")))
                 );
            #endregion Reporte





        }
    }
}
