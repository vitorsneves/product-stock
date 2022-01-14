using Services;

namespace API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services) => 
            services.AddScoped<IProductService, ProductService>();
    }
}