using Elektra.Productos.Tienda.ApplicationServices.Abstractions.Messaging;
using Elektra.Productos.Tienda.DomainModel.Collections;

namespace Elektra.Productos.Tienda.ApplicationServices.UseCases.SearchSku
{
    public record SearchSkuCommand(
        string Sku,
        string Store
  ) : ICommand<IEnumerable<Product>>;
}
