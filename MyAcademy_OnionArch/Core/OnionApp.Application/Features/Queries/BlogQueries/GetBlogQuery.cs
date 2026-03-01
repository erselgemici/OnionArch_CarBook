using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.BlogResults;

namespace OnionApp.Application.Features.Queries.BlogQueries
{
    public record GetBlogQuery() : IRequest<BaseResult<List<GetBlogQueryResult>>>;
}
