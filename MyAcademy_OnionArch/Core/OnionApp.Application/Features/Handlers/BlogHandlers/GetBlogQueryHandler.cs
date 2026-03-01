using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BlogQueries;
using OnionApp.Application.Features.Results.BlogResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler(IRepository<Blog> _repository) : IRequestHandler<GetBlogQuery, BaseResult<List<GetBlogQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogQueryResult>>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetBlogQueryResult>>.Success(values.Adapt<List<GetBlogQueryResult>>());
        }
    }
}
