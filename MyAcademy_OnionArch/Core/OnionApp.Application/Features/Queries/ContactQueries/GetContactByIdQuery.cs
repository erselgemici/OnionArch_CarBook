using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.ContactResults;

namespace OnionApp.Application.Features.Queries.ContactQueries
{
    public record GetContactByIdQuery(int Id) : IRequest<BaseResult<GetContactByIdQueryResult>>;
}
