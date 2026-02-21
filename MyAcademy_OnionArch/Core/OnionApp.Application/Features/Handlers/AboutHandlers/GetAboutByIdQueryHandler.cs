using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.AboutQueries;
using OnionApp.Application.Features.Results.AboutResults;
using OnionApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler(IRepository<About> _repository) : IRequestHandler<GetAboutByIdQuery, BaseResult<GetAboutByIdQueryResult>>
    {
        public async Task<BaseResult<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.Id);

            if (about is null)
            {
                return BaseResult<GetAboutByIdQueryResult>.Fail("Hakkımda bilgisi bulunamadı.");
            }

            var mappedAbout = about.Adapt<GetAboutByIdQueryResult>();

            return BaseResult<GetAboutByIdQueryResult>.Success(mappedAbout);
        }
    }
}
