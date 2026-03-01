using FluentValidation;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Özellik adı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Özellik adı en az 2 karakter olmalıdır.");
        }
    }
}
