using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Lokasyon adı boş olamaz.")
                .MinimumLength(3).WithMessage("Lokasyon adı en az 3 karakter olmalıdır.");
        }
    }
}
