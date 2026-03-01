using FluentValidation;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Müşteri adı boş olamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Unvan alanı boş olamaz.");
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum alanı boş olamaz.")
                .MinimumLength(10).WithMessage("Yorum en az 10 karakter olmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolu boş olamaz.");
        }
    }
}
