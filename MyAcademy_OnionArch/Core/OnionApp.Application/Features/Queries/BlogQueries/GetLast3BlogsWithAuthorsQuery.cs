using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.BlogResults;

namespace OnionApp.Application.Features.Queries.BlogQueries
{
    public class GetLast3BlogsWithAuthorsQuery : IRequest<BaseResult<List<GetLast3BlogsWithAuthorsQueryResult>>>;
    
}
