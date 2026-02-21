using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.ProductResults;

namespace OnionApp.Application.Features.Queries.ProductQueries
{
    public class GetProductByIdQuery(int id) : IRequest<BaseResult<GetProductByIdQueryResult>>
    {
        public int Id { get; set; } = id;
    }
}
