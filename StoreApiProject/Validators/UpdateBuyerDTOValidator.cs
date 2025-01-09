using FluentValidation;
using StoreApiProject.DTOs;

namespace StoreApiProject.Validators
{
    public class UpdateBuyerDTOValidator : AbstractValidator<UpdateBuyerDTO>
    {
        public UpdateBuyerDTOValidator() {
            RuleFor(b => b.BuyerId).NotEmpty().WithMessage("Buyer ID cannot be empty");
            RuleFor(b => b.Name).NotEmpty().WithMessage("Name cannot be empty")
            .Length(1, 50).WithMessage("Name should contain between 1 and 50 characters");

        }
    }
}
