using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektra.Productos.Tienda.DomainModel.Collections
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        private string _collectionName;
        public BsonCollectionAttribute(string collectionName)
        {
            _collectionName = collectionName;
        }
        public string CollectionName => _collectionName;
    }
}
