namespace Ventas.API.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("NuevaPolitica", app =>
                {
                    app.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
