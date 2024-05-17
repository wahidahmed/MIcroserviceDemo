using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            
          return await orderRepository.DeleteAsync(new Domain.Models.Order() { Id=request.Id} );
            
        }
    }
}
