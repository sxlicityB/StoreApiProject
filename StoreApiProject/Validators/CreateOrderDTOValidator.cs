using FluentValidation;
using StoreApiProject.DTOs;

namespace StoreApiProject.Validators
{
    public class CreateOrderDTOValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderDTOValidator() {
            RuleFor(o => o.BuyerId).NotEmpty().WithMessage("Buyer ID cannot be empty");
            RuleFor(o => o.OrderProducts).NotEmpty().WithMessage("Products in order cannot be empty");
        }
    }
}
