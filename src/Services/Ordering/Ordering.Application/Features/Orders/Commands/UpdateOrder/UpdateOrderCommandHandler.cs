using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistance;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = mapper.Map<Order>(request);
           return await orderRepository.UpdateAsync(order);
            
        }
    }
}
