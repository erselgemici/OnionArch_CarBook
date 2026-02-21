using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BrandQueries;
using OnionApp.Application.Features.Results.BrandResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler(IRepository<Brand> _repository) : IRequestHandler<GetBrandQuery, BaseResult<List<GetBrandQueryResult>>>
    {
        public async Task<BaseResult<List<GetBrandQueryResult>>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mapped = values.Adapt<List<GetBrandQueryResult>>();
            return BaseResult<List<GetBrandQueryResult>>.Success(mapped);
        }
    }
}
