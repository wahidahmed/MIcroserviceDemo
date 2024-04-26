using Basket.API.Models;
using Basket.API.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<IActionResult>GetBasket(string userName)
        {
            try
            {
                var basket=await basketRepository.GetBasket(userName);
                return CustomResult("Basket data load successfully",basket);
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof (ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
        {
            try
            {

                return CustomResult("Basket modified done ", await basketRepository.UpdateBasket(basket));
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult>DeleteBasket(string userName)
        {
            try
            {
                await basketRepository.DeleteBasket(userName);
                return CustomResult("Delete Done");
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
