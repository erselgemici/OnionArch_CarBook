using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CarQueries;
using OnionApp.Application.Features.Results.CarResults;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler(IRepository<Car> _repository) : IRequestHandler<GetCarByIdQuery, BaseResult<GetCarByIdQueryResult>>
    {
        public async Task<BaseResult<GetCarByIdQueryResult>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(request.Id);
            if (car == null) return BaseResult<GetCarByIdQueryResult>.Fail("Araç bulunamadı.");
            return BaseResult<GetCarByIdQueryResult>.Success(car.Adapt<GetCarByIdQueryResult>());
        }
    }
}
