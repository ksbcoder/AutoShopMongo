using AutoShopMongo.Infrastructure.EntitiesMongo;
using MongoDB.Driver;

namespace AutoShopMongo.Infrastructure.Interfaces
{
    public interface IContext
    {
        public IMongoCollection<ShopEntity> Shops { get; }
    }
}
