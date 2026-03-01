using OnionApp.Domain.Entities;

namespace OnionApp.Application.Contracts.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsWithAuthorsAsync();
    }
}
