using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.SocialMediaQueries;
using OnionApp.Application.Features.Results.SocialMediaResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler(IRepository<SocialMedia> _repository) : IRequestHandler<GetSocialMediaQuery, BaseResult<List<GetSocialMediaQueryResult>>>
    {
        public async Task<BaseResult<List<GetSocialMediaQueryResult>>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetSocialMediaQueryResult>>.Success(values.Adapt<List<GetSocialMediaQueryResult>>());
        }
    }
}
