using MongoDB.Driver;

namespace CreditApplication.Repository
{
    public abstract class MongoDatabase
    {
        protected readonly MongoClient _client;
        protected readonly IMongoCollection<DataObject> _collectionLog;
        protected readonly IMongoCollection<DataObject> _collection;

        protected MongoDatabase(ICreditMongoSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            var database = _client.GetDatabase(settings.NameDatabaseCredit);
            _collectionLog = database.GetCollection<DataObject>(settings.NameCollectionLog);
            _collection = database.GetCollection<DataObject>(settings.NameCollectionCredit);
        }
    }

    public interface ICreditMongoSettings
    {
        public string ConnectionString { get; }
        public string NameCollectionLog { get; }
        public string NameDatabaseCredit { get; }
        public string NameCollectionCredit { get; }
    }

    public class CreditMongoSettings : ICreditMongoSettings
    {
        public string ConnectionString { get; set; }
        public string NameCollectionLog { get; set; }
        public string NameDatabaseCredit { get; set; }
        public string NameCollectionCredit { get; set; }
    }
}