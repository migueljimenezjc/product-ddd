using Elektra.Productos.Tienda.ApplicationServices.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektra.Productos.Tienda.ApplicationServices.UseCases.InsertSku
{
    public record InsertSkuCommand(
         string Sku,
         string Store,
         string Name
   ) : ICommand<int>;
}
