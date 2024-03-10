using MongoDB.Bson;

namespace Elektra.Productos.Tienda.DomainModel.Collections
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}
