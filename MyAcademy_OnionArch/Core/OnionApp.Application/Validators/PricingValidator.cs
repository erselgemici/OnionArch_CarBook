using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    public class PricingValidator : AbstractValidator<Pricing>
    {
        public PricingValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Fiyatlandırma türü adı boş olamaz.")
                .MaximumLength(50).WithMessage("Fiyatlandırma türü adı 50 karakterden uzun olamaz.");
        }
    }
}
