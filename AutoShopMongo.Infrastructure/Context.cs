using AutoShopMongo.Infrastructure.EntitiesMongo;
using AutoShopMongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace AutoShopMongo.Infrastructure
{
    public class Context : IContext
    {
        public readonly IMongoDatabase _database;

        public Context(string urlConnection, string databaseName)
        {
            MongoClient mongoClient = new MongoClient(urlConnection);
            _database = mongoClient.GetDatabase(databaseName);
        }
        public IMongoCollection<ShopEntity> Shops => _database.GetCollection<ShopEntity>("Shops");
    }
}
