using Sample.MediatR.Persistence.Elasticsearch;
using Nest;
using Elektra.Productos.Tienda.DomainModel.Collections;

namespace Elektra.Productos.Tienda.Persistence.Elasticsearch
{
    public class ElasticRepository<T> : ElasticBaseRepository<T>, IBaseElasticRepository<T> where T : ElasticBaseIndex
    {
        public override string IndexName { get; }

        public ElasticRepository(IElasticClient elasticClient)
            : base(elasticClient)
        {
            IndexName = (typeof(T).GetCustomAttributes(typeof(IndexConfigNameAttribute), true).FirstOrDefault()
                as IndexConfigNameAttribute).Name;
        }
    }
}
