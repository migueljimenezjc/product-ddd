using Elektra.Productos.Tienda.Persistence.Elasticsearch;
using Nest;

namespace Elektra.Productos.Tienda.ApplicationServices.Consumers
{
    public class IndexClient : ElasticBaseIndex
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [Nested]
        public List<IndexProduct> Produtos { get; set; } = new();
    }

    [IndexConfigName("productos")]
    public class IndexProduct : ElasticBaseIndex
    {
        public string Sku { get; set; }
        public string Store { get; set; }
        public string Name { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
