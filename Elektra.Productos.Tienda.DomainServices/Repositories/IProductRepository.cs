using Elektra.Productos.Tienda.DomainModel.Collections;


namespace Elektra.Productos.Tienda.DomainServices.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get(string sku, string store);
        Task<int> Post(Product obj);
    }
}
