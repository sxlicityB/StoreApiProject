using FluentValidation;
using Store_Api_Proj.DTOs;

namespace Store_Api_Proj.Validators
{
    public class CreateBuyerDTOValidator : AbstractValidator<CreateBuyerDTO>
    {
        public CreateBuyerDTOValidator(){
            RuleFor(b => b.Name).NotEmpty().WithMessage("Name cannot be empty")
            .Length(1, 50).WithMessage("Name should contain between 1 and 50 characters");
        }
    }
}
