using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ventas_Angular14_NetCore7.DAL.DBContext;

using Ventas_Angular14_NetCore7.DAL.Repositorios.Contrato;
using Ventas_Angular14_NetCore7.DAL.Repositorios;

namespace Ventas_Angular14_NetCore7.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            //Dependencia base de datos
            services.AddDbContext<VentasAngular14Context>(options => {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            //crear dependencia de los repositorios que habiamos creado (para cualquier modelo:  <>)
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            //Se especifica el modelo
            services.AddScoped<IVentaRepository, VentaRepository>();
        }
    }
}
