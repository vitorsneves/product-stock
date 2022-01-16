using Services;

namespace API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services) => 
            services.AddScoped<IProductService, ProductService>();

        public static IServiceCollection ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            });
    }
}