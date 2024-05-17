using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidation:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Please enter Order Id");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Please enter username")
                                    .EmailAddress().WithMessage("username should be valid email");
        }
    }
}
