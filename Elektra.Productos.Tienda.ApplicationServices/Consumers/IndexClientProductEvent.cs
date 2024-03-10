using Elektra.Productos.Tienda.DomainModel.Collections;
using Elektra.Productos.Tienda.Persistence.Elasticsearch;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektra.Productos.Tienda.ApplicationServices.Consumers
{
    public class Client 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    public class Producto 
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
    }

    public class IndexClientProductEvent
    {
        public Client Client { get; set; }
        public Producto Product { get; set; }
    }
}
