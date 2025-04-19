
using FluentValidation;
using INV.Application.DTO;

namespace INV.Application.Validation
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Please specify a name")
              .MinimumLength(10).WithMessage("Name must have at least 10 characters")
              .MaximumLength(100).WithMessage("Name must be a maximum of 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Please provide a description")
                .MinimumLength(10).WithMessage("Description must have at least 10 characters")
                .MaximumLength(500).WithMessage("Description must be a maximum of 500 characters");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");

        }
    }
}
