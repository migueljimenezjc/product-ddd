using Elektra.Productos.Tienda.DomainModel.Collections;
using Elektra.Productos.Tienda.DomainServices.Repositories;
using Elektra.Productos.Tienda.Persistence.DataAccess.Repository;

namespace Elektra.Productos.Tienda.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoRepository<Product> _productRepository;

        public ProductRepository(IMongoRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> Get(string sku, string store)
        {
            return _productRepository.FilterByAsync(
                filter => filter.Sku == sku && filter.Store == store
                );
        }

        public async Task<int> Post(Product obj)
        {
            await _productRepository.InsertOneAsync(obj);
            return 1;
        }
    }
}
