using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    public class SocialMediaValidator : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Platform adı boş bırakılamaz.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Link boş bırakılamaz.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon alanı boş bırakılamaz.");
        }
    }
}
