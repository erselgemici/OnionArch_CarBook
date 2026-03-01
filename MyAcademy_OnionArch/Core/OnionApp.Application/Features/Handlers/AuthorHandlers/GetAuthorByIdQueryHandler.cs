using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.AuthorQueries;
using OnionApp.Application.Features.Results.AuthorResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler(IRepository<Author> _repository) : IRequestHandler<GetAuthorByIdQuery, BaseResult<GetAuthorByIdQueryResult>>
    {
        public async Task<BaseResult<GetAuthorByIdQueryResult>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null) return BaseResult<GetAuthorByIdQueryResult>.Fail("Yazar bulunamadı.");
            return BaseResult<GetAuthorByIdQueryResult>.Success(value.Adapt<GetAuthorByIdQueryResult>());
        }
    }
}
