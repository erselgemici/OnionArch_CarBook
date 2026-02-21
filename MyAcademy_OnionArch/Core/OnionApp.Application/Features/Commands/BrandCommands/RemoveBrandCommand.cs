using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.BrandCommands
{
    public record RemoveBrandCommand(int Id) : IRequest<BaseResult<object>>;
}
