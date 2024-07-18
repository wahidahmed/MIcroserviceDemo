using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistance;
using Ordering.Application.Models;
using Ordering.Domain.Models;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper,IEmailService emailService)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.emailService = emailService;
        }
        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order=mapper.Map<Order>(request);
            order.CreatedBy = "1";
            order.CreatedDate = DateTime.Now;  
          var isPLaced= await orderRepository.AddAsync(order);
            if (isPLaced)
            {
                EmailMessage email=new();
                email.Subject = "order placed";
                email.To = order.UserName;
                email.Body = $"Dear {order.FirstName +" "+ order.LastName} <br/><br/> we have received your order and your order id is ${order.Id}";
               //await emailService.SendEmailAsync(email);
            }

            return isPLaced;
        }
    }
}
