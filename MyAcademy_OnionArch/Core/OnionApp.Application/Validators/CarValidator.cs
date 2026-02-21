using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model bilgisi boş olamaz.");
            RuleFor(x => x.BrandID).GreaterThan(0).WithMessage("Geçerli bir marka seçiniz.");
            RuleFor(x => x.Km).GreaterThanOrEqualTo(0).WithMessage("Kilometre negatif olamaz.");
            RuleFor(x => x.Seat).InclusiveBetween((byte)1, (byte)10).WithMessage("Koltuk sayısı 1-10 arasında olmalıdır.");
            RuleFor(x => x.Transmission).NotEmpty().WithMessage("Vites türü belirtilmelidir.");
            RuleFor(x => x.Fuel).NotEmpty().WithMessage("Yakıt türü belirtilmelidir.");
        }
    }
}
