using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Comun;
using Ventas.BusinessLogicLayer.Menus;
using Ventas.BusinessLogicLayer.Productos;
using Ventas.BusinessLogicLayer.Usuarios;
using Ventas.BusinessLogicLayer.Ventas;
using Ventas.DataAccessLayer.DBContext;
using Ventas.DataAccessLayer.Repositorios;

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
            services.AddScoped<IRolManager, RolManager>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();
            services.AddScoped<ICategoriaManager, CategoriaManager>();
            services.AddScoped<IProductoManager, ProductoManager>();
            services.AddScoped<IVentaManager, VentaManager>();
            services.AddScoped<IDashBoardManager, DashBoardManager>();
            services.AddScoped<IMenuManager, MenuManager>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        }
    }
}
