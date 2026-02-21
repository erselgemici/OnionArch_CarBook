using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.AboutResults;

namespace OnionApp.Application.Features.Queries.AboutQueries
{
    public class GetAboutQuery : IRequest<BaseResult<List<GetAboutQueryResult>>>
    {
    }
}
