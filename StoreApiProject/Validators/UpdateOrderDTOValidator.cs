using FluentValidation;
using StoreApiProject.DTOs;
using StoreApiProject.Models;

namespace StoreApiProject.Validators
{
    public class UpdateOrderDTOValidator : AbstractValidator<UpdateOrderDTO>
    {
        public UpdateOrderDTOValidator(){
            RuleFor(o => o.OrderId).NotEmpty().WithMessage("Order id cannot be empty");
            RuleFor(o => o.BuyerId).NotEmpty().WithMessage("Buyer id cannot be empty");
            RuleFor(o => o.Status).IsInEnum().WithMessage("Must contain valid status");

        }
    }
}
