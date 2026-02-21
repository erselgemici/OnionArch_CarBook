using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
            .MinimumLength(5).WithMessage("Açıklama en az 5 karakter olmalıdır.");
        }
    }
}
