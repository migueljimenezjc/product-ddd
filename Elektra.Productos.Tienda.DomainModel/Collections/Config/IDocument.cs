using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Elektra.Productos.Tienda.DomainModel.Collections
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }
        DateTime CreatedAt { get; }
    }
}
