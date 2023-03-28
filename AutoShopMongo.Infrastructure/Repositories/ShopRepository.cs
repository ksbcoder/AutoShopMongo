using AutoMapper;
using AutoShopMongo.Domain.Commands;
using AutoShopMongo.Domain.Entities;
using AutoShopMongo.Domain.UseCases.Gateway.Repositories;
using AutoShopMongo.Infrastructure.EntitiesMongo;
using AutoShopMongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace AutoShopMongo.Infrastructure.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly IMongoCollection<ShopEntity> shopCollection;
        private readonly IMapper _mapper;

        public ShopRepository(IContext context, IMapper mapper)
        {
            shopCollection = context.Shops;
            _mapper = mapper;
        }

        public async Task<NewShop> CreateShop(Shop shop)
        {
            var shopToCreate = _mapper.Map<ShopEntity>(shop);
            await shopCollection.InsertOneAsync(shopToCreate);
            return _mapper.Map<NewShop>(shop);
        }

        public async Task<List<Shop>> GetShops()
        {
            var shops = await shopCollection.FindAsync(shopEntity => true && shopEntity.State_shop == true);
            var shopsList = _mapper.Map<List<Shop>>(shops.ToList());
            if (shopsList.Count == 0)
            {
                throw new ArgumentException("There aren't shops to show.");
            }
            return shopsList;
        }

        public async Task<Shop> UpdateShop(Shop shop)
        {
            var shopToUpdate = _mapper.Map<ShopEntity>(shop);
            var shopUpdated = await shopCollection.FindOneAndReplaceAsync(shopEntity => shopEntity.Shop_id == shop.Shop_id
                    && shopEntity.State_shop == true, shopToUpdate);

            return shopUpdated == null
                ? throw new ArgumentException($"There isn't a shop with this ID: {shop.Shop_id}.")
                : _mapper.Map<Shop>(shopToUpdate);
        }

        public async Task<string> DeleteShop(string id)
        {
            var shops = await GetShops();
            var shopToDelete = shops.FirstOrDefault(shopList => shopList.Shop_id == id);
            if (shopToDelete != null)
            {
                shopToDelete.State_shop = false;
                await UpdateShop(shopToDelete);
            }
            else
            {
                throw new ArgumentException($"There isn't a shop with this ID: {id}.");
            }
            return $"Delete Successful for ID: {id}";
        }
    }
}
