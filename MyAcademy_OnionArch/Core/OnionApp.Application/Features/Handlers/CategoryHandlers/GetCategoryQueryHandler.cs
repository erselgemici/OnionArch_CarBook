using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CategoryQueries;
using OnionApp.Application.Features.Results.CategoryResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler(IRepository<Category> _repository) : IRequestHandler<GetCategoryQuery, BaseResult<List<GetCategoryQueryResult>>>
    {
        public async Task<BaseResult<List<GetCategoryQueryResult>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            var mappedCategories = categories.Adapt<List<GetCategoryQueryResult>>();

            return BaseResult<List<GetCategoryQueryResult>>.Success(mappedCategories);
        }
    }
}
