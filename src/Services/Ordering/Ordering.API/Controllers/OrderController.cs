using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Queries.GetOrdersByUserName;
using System.Net;
using CoreApiResponse;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)  
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderVM>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderByUsername(string username)
        {
            try
            {
                var orders=await mediator.Send(new GetOrdersByUserQuery(username));
                return CustomResult("Order load successfully", orders);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand orderCommand)
        {
            try
            {
                var isOrderPlaced = await mediator.Send(orderCommand);
                if (isOrderPlaced)
                {
                    return CustomResult("Order placed successfully");
                }
                else
                {
                    return CustomResult("Order not placed",HttpStatusCode.BadRequest);
                }
               
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand orderCommand)
        {
            try
            {
                var isModified = await mediator.Send(orderCommand);
                if (isModified)
                {
                    return CustomResult("Order modified successfully");
                }
                else
                {
                    return CustomResult("Order not modified", HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOrder(int orderid)
        {
            try
            {
                var isDelete = await mediator.Send(new DeleteOrderCommand { Id = orderid });
                if (isDelete)
                {
                    return CustomResult("Order deleted successfully");
                }
                else
                {
                    return CustomResult("Order not deleted", HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
