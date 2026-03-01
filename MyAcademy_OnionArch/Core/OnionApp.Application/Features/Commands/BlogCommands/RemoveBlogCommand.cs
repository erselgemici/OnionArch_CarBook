using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.BlogCommands
{
    public record RemoveBlogCommand(int Id) : IRequest<BaseResult<object>>;
}
