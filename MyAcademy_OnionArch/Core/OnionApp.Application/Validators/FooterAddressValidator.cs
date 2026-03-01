using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    public class FooterAddressValidator : AbstractValidator<FooterAddress>
    {
        public FooterAddressValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş olamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş olamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-posta giriniz.");
        }
    }
}
