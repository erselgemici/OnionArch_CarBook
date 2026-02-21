using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.CategoryResults;

namespace OnionApp.Application.Features.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<BaseResult<List<GetCategoryQueryResult>>>
    {
    }
}
