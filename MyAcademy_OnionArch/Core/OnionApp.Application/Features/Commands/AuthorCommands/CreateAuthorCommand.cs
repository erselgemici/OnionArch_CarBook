using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.AuthorCommands
{
    public record CreateAuthorCommand(string Name, string ImageUrl, string Description) : IRequest<BaseResult<object>>;
}
