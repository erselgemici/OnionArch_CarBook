using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.BrandCommands
{
    public record CreateBrandCommand(string Name) : IRequest<BaseResult<object>>;
}
