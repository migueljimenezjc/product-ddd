using Elektra.Productos.Tienda.ApplicationServices.UseCases.InsertSku;
using Elektra.Productos.Tienda.ApplicationServices.UseCases.SearchSku;
using Microsoft.Extensions.DependencyInjection;


namespace Elektra.Productos.Tienda.ApplicationServices
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationService(
            this IServiceCollection services
            )
        {
            services.AddMediatR(cfg =>
              cfg.RegisterServicesFromAssemblies(typeof(InsertSkuUseCase).Assembly)
                 .RegisterServicesFromAssemblies(typeof(SearchSkuUseCase).Assembly)
            );
            return services;
        }
    }
}
