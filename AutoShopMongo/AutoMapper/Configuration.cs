using AutoMapper;
using AutoShopMongo.Domain.Commands;
using AutoShopMongo.Domain.Entities;
using AutoShopMongo.Infrastructure.EntitiesMongo;

namespace AutoShopMongo.API.AutoMapper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<NewShop, Shop>().ReverseMap();
            CreateMap<ShopEntity, Shop>().ReverseMap();

            CreateMap<NewCustomer, Customer>().ReverseMap();
            CreateMap<NewVehicle, Vehicle>().ReverseMap();
        }
    }
}
