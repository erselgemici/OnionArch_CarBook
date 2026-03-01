using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.BlogCommands
{
    public record CreateBlogCommand(string Title, string CoverImageUrl, DateTime CreatedDate, int AuthorID, int CategoryID) : IRequest<BaseResult<object>>;
}
