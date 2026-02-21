using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.ContactQueries;
using OnionApp.Application.Features.Results.ContactResults;
using OnionApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler(IRepository<Contact> _repository) : IRequestHandler<GetContactByIdQuery, BaseResult<GetContactByIdQueryResult>>
    {
        public async Task<BaseResult<GetContactByIdQueryResult>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
            {
                return BaseResult<GetContactByIdQueryResult>.Fail("İlgili iletişim mesajı bulunamadı.");
            }

            var mappedValue = value.Adapt<GetContactByIdQueryResult>();
            return BaseResult<GetContactByIdQueryResult>.Success(mappedValue);
        }
    }
}
