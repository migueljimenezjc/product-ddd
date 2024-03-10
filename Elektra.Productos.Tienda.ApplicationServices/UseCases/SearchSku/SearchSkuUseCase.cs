using Elektra.Productos.Tienda.ApplicationServices.Abstractions.Messaging;
using Elektra.Productos.Tienda.DomainModel.Collections;
using Elektra.Productos.Tienda.DomainServices.Repositories;

namespace Elektra.Productos.Tienda.ApplicationServices.UseCases.SearchSku
{
    public class SearchSkuUseCase : ICommandHandler<SearchSkuCommand, IEnumerable<Product>>
    {
        private readonly IProductRepository Repository;
        public SearchSkuUseCase(IProductRepository repository)
        {
            Repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(SearchSkuCommand request, CancellationToken cancellationToken)
        {
            return await Repository.Get(request.Sku, request.Store);
        }
    }
}
