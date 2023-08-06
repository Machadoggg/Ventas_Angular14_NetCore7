using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ventas_Angular14_NetCore7.DAL.DBContext;

namespace Ventas_Angular14_NetCore7.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VentasAngular14Context>(options => {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });
        }
    }
}
