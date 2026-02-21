using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.ProductCommands
{
    public class RemoveProductCommand(int id) : IRequest<BaseResult<object>>
    {
        public int Id { get; set; } = id;
    }
}
