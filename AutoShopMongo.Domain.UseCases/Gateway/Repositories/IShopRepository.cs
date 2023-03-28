using AutoShopMongo.Domain.Commands;
using AutoShopMongo.Domain.Entities;

namespace AutoShopMongo.Domain.UseCases.Gateway.Repositories
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetShops();
        Task<NewShop> CreateShop(Shop shop);
        Task<Shop> UpdateShop(Shop shop);
    }
}
