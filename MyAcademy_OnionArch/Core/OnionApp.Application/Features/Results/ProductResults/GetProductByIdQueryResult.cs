using MediatR;
using OnionApp.Application.Features.Results.CategoryResults;

namespace OnionApp.Application.Features.Results.ProductResults
{
    public class GetProductByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryResult Category { get; set; }
    }
}
