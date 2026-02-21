using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ContactQueries;
using OnionApp.Application.Features.Results.ContactResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ContactHandlers
{
    public class GetContactQueryHandler(IRepository<Contact> _repository) : IRequestHandler<GetContactQuery, BaseResult<List<GetContactQueryResult>>>
    {
        public async Task<BaseResult<List<GetContactQueryResult>>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetContactQueryResult>>.Success(values.Adapt<List<GetContactQueryResult>>());
        }
    }
}
