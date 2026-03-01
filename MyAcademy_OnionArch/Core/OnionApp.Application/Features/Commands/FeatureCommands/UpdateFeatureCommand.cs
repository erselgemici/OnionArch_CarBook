using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.FeatureCommands
{
    public record UpdateFeatureCommand(int FeatureID, string Name) : IRequest<BaseResult<object>>;
}
