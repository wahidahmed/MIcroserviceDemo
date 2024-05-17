using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersByUserName
{
    public class GetOrdersByUserQuery:IRequest<List<OrderVM>>
    {
        public string UserName { get; set; }
        public GetOrdersByUserQuery(string username)
        {
        UserName = username;
        }
    }
}
