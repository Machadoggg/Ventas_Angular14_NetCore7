using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Servicios;
using Ventas.BusinessLogicLayer.Servicios.Contrato;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios;
using Ventas.DataAccessLayer.Repositorios.Contrato;

namespace Ventas.API.Utilidad
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
