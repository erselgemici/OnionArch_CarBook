using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.ValidationRules
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Marka adı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Marka adı en az 2 karakter olmalıdır.");
        }
    }
}
