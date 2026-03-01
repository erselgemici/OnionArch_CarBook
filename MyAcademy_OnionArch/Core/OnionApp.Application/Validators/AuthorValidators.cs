using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolu boş bırakılamaz.");
        }
    }
}
