using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.SocialMediaResults;

namespace OnionApp.Application.Features.Queries.SocialMediaQueries
{
    public record GetSocialMediaQuery() : IRequest<BaseResult<List<GetSocialMediaQueryResult>>>;
}
