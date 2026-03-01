using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.FeatureCommands
{
    public record CreateFeatureCommand(string Name) : IRequest<BaseResult<object>>;
}
