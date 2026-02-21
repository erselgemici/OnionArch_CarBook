using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.AboutQueries;
using OnionApp.Application.Features.Results.AboutResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler(IRepository<About> _repository) : IRequestHandler<GetAboutQuery, BaseResult<List<GetAboutQueryResult>>>
    {
        public async Task<BaseResult<List<GetAboutQueryResult>>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            var mappedValues = values.Adapt<List<GetAboutQueryResult>>();

            return BaseResult<List<GetAboutQueryResult>>.Success(mappedValues);
        }
    }
}
