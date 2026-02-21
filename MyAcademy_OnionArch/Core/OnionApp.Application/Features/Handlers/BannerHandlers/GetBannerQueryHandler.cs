using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BannerQueries;
using OnionApp.Application.Features.Results.BannerResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler(IRepository<Banner> _repository) : IRequestHandler<GetBannerQuery, BaseResult<List<GetBannerQueryResult>>>
    {
        public async Task<BaseResult<List<GetBannerQueryResult>>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetBannerQueryResult>>.Success(values.Adapt<List<GetBannerQueryResult>>());
        }
    }
}
