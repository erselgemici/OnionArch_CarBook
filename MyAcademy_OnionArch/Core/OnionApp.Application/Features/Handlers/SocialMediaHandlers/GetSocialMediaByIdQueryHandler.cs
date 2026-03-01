using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.SocialMediaQueries;
using OnionApp.Application.Features.Results.SocialMediaResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> _repository) : IRequestHandler<GetSocialMediaByIdQuery, BaseResult<GetSocialMediaByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialMediaByIdQueryResult>> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetSocialMediaByIdQueryResult>.Fail("Sosyal medya hesabı bulunamadı.");
            return BaseResult<GetSocialMediaByIdQueryResult>.Success(value.Adapt<GetSocialMediaByIdQueryResult>());
        }
    }
}
