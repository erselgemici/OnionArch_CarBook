using FluentValidation;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.ValidationRules.BlogValidators
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığı boş bırakılamaz.");
            RuleFor(x => x.CoverImageUrl).NotEmpty().WithMessage("Kapak görseli boş bırakılamaz.");
            RuleFor(x => x.AuthorID).GreaterThan(0).WithMessage("Geçerli bir yazar seçilmelidir.");
            RuleFor(x => x.CategoryID).GreaterThan(0).WithMessage("Geçerli bir kategori seçilmelidir.");
        }
    }
}
