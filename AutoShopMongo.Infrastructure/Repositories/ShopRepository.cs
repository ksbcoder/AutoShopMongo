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
            return _mapper.Map<List<Shop>>(shops.ToList());
        }

        public async Task<Shop> UpdateShop(Shop shop)
        {
            var shopToUpdate = _mapper.Map<ShopEntity>(shop);
            var shopUpdated = await shopCollection.FindOneAndReplaceAsync(shopEntity => shopEntity.Shop_id == shop.Shop_id, shopToUpdate);
            return _mapper.Map<Shop>(shopToUpdate);
        }
    }
}
