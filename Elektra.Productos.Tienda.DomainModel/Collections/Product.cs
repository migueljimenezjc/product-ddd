
namespace Elektra.Productos.Tienda.DomainModel.Collections
{
    [BsonCollection("Productos")]
    public class Product:Document 
    {
        public string Sku { get; set; }
        public string Store { get; set; }
        public string Name { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
