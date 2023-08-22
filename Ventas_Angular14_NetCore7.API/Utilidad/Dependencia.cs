using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ventas_Angular14_NetCore7.BLL.Servicios;
using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;
using Ventas_Angular14_NetCore7.DAL.DBContext;
using Ventas_Angular14_NetCore7.DAL.Repositorios;
using Ventas_Angular14_NetCore7.DAL.Repositorios.Contrato;
using Ventas_Angular14_NetCore7.API.Utilidad;
using AutoMapper;

namespace Ventas_Angular14_NetCore7.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            //Dependencia base de datos
            services.AddDbContext<VentasAngular14Context>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            //crear dependencia de los repositorios que habiamos creado (para cualquier modelo:  <>)
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //Se especifica el modelo
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddAutoMapper(typeof(AutomapperProfile));

            //Agregar las dependencias de todos los servicios
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IVentaService, VentaService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IMenuService, MenuService>();
        }
    }
}
