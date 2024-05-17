using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class UpdateOrderCommandValidation:AbstractValidator<CreateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Please enter username")
                                    .EmailAddress().WithMessage("username should be valid email");
        }
    }
}
