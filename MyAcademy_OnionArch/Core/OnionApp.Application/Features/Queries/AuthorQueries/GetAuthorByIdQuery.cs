using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.AuthorResults;

namespace OnionApp.Application.Features.Queries.AuthorQueries
{
    public record GetAuthorByIdQuery(int Id) : IRequest<BaseResult<GetAuthorByIdQueryResult>>;
}
