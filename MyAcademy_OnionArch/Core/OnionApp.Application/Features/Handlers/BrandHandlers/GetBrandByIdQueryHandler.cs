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
    public class GetBrandByIdQueryHandler(IRepository<Brand> _repository) : IRequestHandler<GetBrandByIdQuery, BaseResult<GetBrandByIdQueryResult>>
    {
        public async Task<BaseResult<GetBrandByIdQueryResult>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _repository.GetByIdAsync(request.Id);
            if (brand == null) return BaseResult<GetBrandByIdQueryResult>.Fail("Marka bulunamadı.");

            return BaseResult<GetBrandByIdQueryResult>.Success(brand.Adapt<GetBrandByIdQueryResult>());
        }
    }
}
