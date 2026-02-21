using OnionApp.Application.Features.Results.CategoryResults;

namespace OnionApp.Application.Features.Results.ProductResults
{
    public class GetProductsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryResult Category { get; set; }
    }
}
