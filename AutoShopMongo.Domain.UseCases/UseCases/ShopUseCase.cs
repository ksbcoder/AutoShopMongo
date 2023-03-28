using AutoShopMongo.Domain.Commands;
using AutoShopMongo.Domain.Entities;
using AutoShopMongo.Domain.UseCases.Gateway;
using AutoShopMongo.Domain.UseCases.Gateway.Repositories;

namespace AutoShopMongo.Domain.UseCases.UseCases
{
    public class ShopUseCase : IShopUseCase
    {
        private readonly IShopRepository _shopRepository;

        public ShopUseCase(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public async Task<NewShop> CreateShop(Shop shop)
        {
            return await _shopRepository.CreateShop(shop);
        }
        public async Task<List<Shop>> GetShops()
        {
            return await _shopRepository.GetShops();
        }

        public async Task<Shop> UpdateShop(Shop shop)
        {
            return await _shopRepository.UpdateShop(shop);
        }
    }
}
