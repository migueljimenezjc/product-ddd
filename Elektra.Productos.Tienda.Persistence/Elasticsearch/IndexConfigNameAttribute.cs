namespace Elektra.Productos.Tienda.Persistence.Elasticsearch
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class IndexConfigNameAttribute : Attribute
    {
        private string _name;
        public IndexConfigNameAttribute(string name)
        {
            _name = name;
        }
        public string Name => _name;
    }
}