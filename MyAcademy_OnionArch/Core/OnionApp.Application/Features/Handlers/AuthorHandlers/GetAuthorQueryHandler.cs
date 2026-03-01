using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.AuthorQueries;
using OnionApp.Application.Features.Results.AuthorResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler(IRepository<Author> _repository) : IRequestHandler<GetAuthorQuery, BaseResult<List<GetAuthorQueryResult>>>
    {
        public async Task<BaseResult<List<GetAuthorQueryResult>>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return BaseResult<List<GetAuthorQueryResult>>.Success(values.Adapt<List<GetAuthorQueryResult>>());
        }
    }
}
