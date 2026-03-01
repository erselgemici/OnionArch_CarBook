using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts.BlogInterfaces;
using OnionApp.Application.Features.Queries.BlogQueries;
using OnionApp.Application.Features.Results.BlogResults;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository _repository)
        : IRequestHandler<GetLast3BlogsWithAuthorsQuery, BaseResult<List<GetLast3BlogsWithAuthorsQueryResult>>>
    {
        public async Task<BaseResult<List<GetLast3BlogsWithAuthorsQueryResult>>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetLast3BlogsWithAuthorsAsync();

            return BaseResult<List<GetLast3BlogsWithAuthorsQueryResult>>.Success(values.Adapt<List<GetLast3BlogsWithAuthorsQueryResult>>());
        }
    }
}
