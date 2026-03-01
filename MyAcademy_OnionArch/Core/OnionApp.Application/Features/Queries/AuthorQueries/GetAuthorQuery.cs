using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.AuthorResults;

namespace OnionApp.Application.Features.Queries.AuthorQueries
{
    public record GetAuthorQuery() : IRequest<BaseResult<List<GetAuthorQueryResult>>>;
}
