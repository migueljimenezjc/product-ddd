

namespace Elektra.Productos.Tienda.Persistence.Elasticsearch
{
    public interface IBaseElasticRepository<T> : IElasticBaseRepository<T> where T : class
    {
    }
}
