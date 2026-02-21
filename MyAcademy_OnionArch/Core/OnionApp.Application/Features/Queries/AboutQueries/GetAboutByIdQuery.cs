using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Results.AboutResults;

namespace OnionApp.Application.Features.Queries.AboutQueries
{
    public class GetAboutByIdQuery : IRequest<BaseResult<GetAboutByIdQueryResult>>
    {
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        
    }
}
