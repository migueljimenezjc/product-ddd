using Elektra.Productos.Tienda.DomainModel.Collections;
using Elektra.Productos.Tienda.Persistence.DataAccess.Config;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Elektra.Productos.Tienda.Persistence.DataAccess.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument>
        where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private static string GetCollectionName(Type typeDocument)
        {
            return (typeDocument.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
                as BsonCollectionAttribute).CollectionName;
        }

        public IQueryable<TDocument> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public void DeleteById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            _collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
        }

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        public IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public TDocument FindById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            return _collection.Find(filter).SingleOrDefault();
        }

        public Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }

        public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            _collection.InsertMany(documents);
        }

        public async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public void InsertOne(TDocument document)
        {
            _collection.InsertOne(document);
        }

        public Task InsertOneAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public void ReplaceOne(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public Task<IEnumerable<TDocument>> FilterByAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).ToEnumerable());
        }
    }
}
