using MediatR;
using OnionApp.Application.Base;

namespace OnionApp.Application.Features.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<BaseResult<object>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
