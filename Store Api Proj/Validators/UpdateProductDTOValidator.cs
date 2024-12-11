using FluentValidation;
using Store_Api_Proj.DTOs;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.Validators
{
    public class UpdateProductDTOValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductDTOValidator()
        {
            RuleFor(p => p.Brand).NotEmpty().WithMessage("Brand field cannot be empty");    //Later to implement existing brand validation
            RuleFor(p => p.Type).NotEmpty().WithMessage("Type field cannot be empty");     // Same thing
            RuleFor(p => p.Availability).NotEmpty().WithMessage("Availability field has to be set to true or false");
            RuleFor(p => p.Price).LessThan(10000).NotEmpty().WithMessage("Price has to be between 10,000 and 0");

        }
    }
}
