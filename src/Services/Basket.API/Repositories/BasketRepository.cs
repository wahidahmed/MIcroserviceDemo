using Basket.API.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCashe;

        public BasketRepository(IDistributedCache distributedCache)
        {
            this._redisCashe = distributedCache;
        }
        public async Task DeleteBasket(string userName)
        {
            await _redisCashe.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket=await _redisCashe.GetStringAsync(userName);
            if(string.IsNullOrEmpty(basket))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            var data=JsonConvert.SerializeObject(basket);
            await _redisCashe.SetStringAsync(basket.UserName, data);
            return await GetBasket(basket.UserName);
        }
    }
}
