using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ServiceQueries;
using OnionApp.Application.Features.Results.ServiceResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler(IRepository<Service> _repository) : IRequestHandler<GetServiceQuery, BaseResult<List<GetServiceQueryResult>>>
    {
        public async Task<BaseResult<List<GetServiceQueryResult>>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetServiceQueryResult>>.Success(values.Adapt<List<GetServiceQueryResult>>());
        }
    }
}
