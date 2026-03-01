using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BlogQueries;
using OnionApp.Application.Features.Results.BlogResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler(IRepository<Blog> _repository) : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetBlogByIdQueryResult>.Fail("Blog yazısı bulunamadı.");
            return BaseResult<GetBlogByIdQueryResult>.Success(value.Adapt<GetBlogByIdQueryResult>());
        }
    }
}
