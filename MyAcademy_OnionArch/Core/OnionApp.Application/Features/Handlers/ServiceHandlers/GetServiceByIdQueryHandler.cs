using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ServiceQueries;
using OnionApp.Application.Features.Results.ServiceResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler(IRepository<Service> _repository) : IRequestHandler<GetServiceByIdQuery, BaseResult<GetServiceByIdQueryResult>>
    {
        public async Task<BaseResult<GetServiceByIdQueryResult>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetServiceByIdQueryResult>.Fail("Hizmet bulunamadı.");
            return BaseResult<GetServiceByIdQueryResult>.Success(value.Adapt<GetServiceByIdQueryResult>());
        }
    }
}
