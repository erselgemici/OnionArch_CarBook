using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Hizmet başlığı boş olamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Hizmet açıklaması boş olamaz.");
            RuleFor(x => x.IconUrl).NotEmpty().WithMessage("İkon yolu boş olamaz.");
        }
    }
}
