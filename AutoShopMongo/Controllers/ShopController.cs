using AutoMapper;
using AutoShopMongo.Domain.Commands;
using AutoShopMongo.Domain.Entities;
using AutoShopMongo.Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopMongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopUseCase _shopUseCase;
        private readonly IMapper _mapper;

        public ShopController(IShopUseCase shopUseCase, IMapper mapper)
        {
            _shopUseCase = shopUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Shop>> GetShopsAsync()
        {
            return await _shopUseCase.GetShops();
        }

        [HttpPost]
        public async Task<NewShop> CreateShopAsync([FromBody] NewShop newShop)
        {
            return await _shopUseCase.CreateShop(_mapper.Map<Shop>(newShop));
        }

        [HttpPut]
        public async Task<Shop> UpdateShopAsync([FromBody] Shop shop)
        {
            return await _shopUseCase.UpdateShop(shop);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteShopAsync(string id)
        {
            return await _shopUseCase.DeleteShop(id);
        }
    }
}
