using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators
{
    //public class ProductValidator : AbstractValidator<Product>
    //{
    //    public ProductValidator()
    //    {
    //        RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
    //                            .MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır.");

    //        RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün açıklaması boş bırakılamaz.");

    //        RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş bırakılamaz.")
    //                             .GreaterThanOrEqualTo(0).WithMessage("Ürün fiyatı eksi değer alamaz.")
    //                             .LessThan(10000).WithMessage("Ürün fiyatı maksimum 10000 TL olmalıdır.");

    //        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori boş bırakılamaz.");

    //    }
    //}
}
