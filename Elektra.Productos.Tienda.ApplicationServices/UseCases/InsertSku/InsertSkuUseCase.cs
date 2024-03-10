using Elektra.Productos.Tienda.ApplicationServices.Abstractions.Messaging;
using Elektra.Productos.Tienda.ApplicationServices.Consumers;
using Elektra.Productos.Tienda.DomainModel.Collections;
using Elektra.Productos.Tienda.DomainServices.Repositories;
using Elektra.Productos.Tienda.Persistence.Elasticsearch;
using MassTransit;

namespace Elektra.Productos.Tienda.ApplicationServices.UseCases.InsertSku
{
    public class InsertSkuUseCase : ICommandHandler<InsertSkuCommand, int>
    {
        private readonly IProductRepository Repository;
        private readonly IBaseElasticRepository<IndexProduct> _indexClient;
        public InsertSkuUseCase(IProductRepository repository,
            IBaseElasticRepository<IndexProduct> indexClient)
        {
            Repository = repository;
            _indexClient = indexClient;
        }

        public async Task<int> Handle(InsertSkuCommand request, CancellationToken cancellationToken)
        {
            await _indexClient.InsertAsync(new IndexProduct() { Sku = request.Sku, Name = request.Name, 
                Store = request.Store  });
            
            var busca = Repository.Get(request.Sku, request.Store);
            if (busca.Result.Count() > 0)
            {
                return 0;
            }
            Product newProduct = new Product();
            newProduct.Sku = request.Sku;
            newProduct.Store = request.Store;
            newProduct.Name = request.Name;
            newProduct.DateAdd = DateTime.Now;
            newProduct.DateUpdate = DateTime.Now;
            await Repository.Post(newProduct);
            return 1;
        }
    }
}
