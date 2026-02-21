using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.BannerQueries;
using OnionApp.Application.Features.Results.BannerResults;
using OnionApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler(IRepository<Banner> _repository) : IRequestHandler<GetBannerByIdQuery, BaseResult<GetBannerByIdQueryResult>>
    {
        public async Task<BaseResult<GetBannerByIdQueryResult>> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetByIdAsync(request.Id);

            if (banner is null)
            {
                return BaseResult<GetBannerByIdQueryResult>.Fail("Aranan afiş (banner) bulunamadı.");
            }

            var mappedBanner = banner.Adapt<GetBannerByIdQueryResult>();

            return BaseResult<GetBannerByIdQueryResult>.Success(mappedBanner);
        }
    }
}
