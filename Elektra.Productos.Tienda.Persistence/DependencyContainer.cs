using Elektra.Productos.Tienda.DomainServices.Repositories;
using Elektra.Productos.Tienda.Persistence.DataAccess.Repository;
using Elektra.Productos.Tienda.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Elektra.Productos.Tienda.Persistence
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersistences(
            this IServiceCollection services
            )
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
