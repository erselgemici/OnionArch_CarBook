using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.AuthorCommands
{
    public record UpdateAuthorCommand(int AuthorID, string Name, string ImageUrl, string Description) : IRequest<BaseResult<object>>;
}
