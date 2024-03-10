using Elastic.Apm.NetCoreAll;
using Elektra.Productos.Tienda.Persistence.Elasticsearch;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nest;

namespace Elektra.Productos.Tienda.WebApi.Core.Extensions
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultIndex = configuration["ElasticsearchSettings:defaultIndex"];
            var basicAuthUser = configuration["ElasticsearchSettings:username"];
            var basicAuthPassword = configuration["ElasticsearchSettings:password"];

            var settings = new ConnectionSettings(new Uri(configuration["ElasticsearchSettings:uri"]));
            
            if (!string.IsNullOrEmpty(defaultIndex))
                settings = settings.DefaultIndex(defaultIndex);

            if (!string.IsNullOrEmpty(basicAuthUser) && !string.IsNullOrEmpty(basicAuthPassword))
                settings = settings.BasicAuthentication(basicAuthUser,basicAuthPassword);  //ApiKeyAuthentication("Mercadeo:dXMtZWFzdC0xLmF3cy5mb3VuZC5pbyQzZGUwM2Q4YzNkMmQ0Y2ZiYTA0NWU4Mzk0ODFmYTFhYiRmYTYzNmNlMGNlYjk0ZWRiODc2MGExODkzYjZjODRhOA==", "Snp5SUZJMEJzTXphOWRzaGtmVy06RVJTdGJqWlVUUktVYm9qVXE4MEp0Zw==");// BasicAuthentication(basicAuthUser, basicAuthPassword);

            settings.EnableApiVersioningHeader();

            var client = new ElasticClient(settings);
            
            services.AddSingleton<IElasticClient>(client);
            services.TryAddScoped(typeof(IBaseElasticRepository<>), typeof(ElasticRepository<>));
        }

        public static void UseElasticApm(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseAllElasticApm(configuration);
        }
    }
}
