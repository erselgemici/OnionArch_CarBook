using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.AuthorCommands
{
    public record RemoveAuthorCommand(int Id) : IRequest<BaseResult<object>>;
}
