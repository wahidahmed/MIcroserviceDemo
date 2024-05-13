using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistance;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersByUserName
{
    public class GetOrdersByUserHandler : IRequestHandler<GetOrdersByUserQuery, List<OrderVM>>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public GetOrdersByUserHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<List<OrderVM>> Handle(GetOrdersByUserQuery request, CancellationToken cancellationToken)
        {
           var orders =await orderRepository.GetOrdersByUserName(request.UserName);
            return mapper.Map<List<OrderVM>>(orders);

        }
    }
}
