using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektra.Productos.Tienda.Persistence.Elasticsearch
{
    public abstract class ElasticBaseIndex
    {
        public string Id { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
