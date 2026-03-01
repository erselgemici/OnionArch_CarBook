using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Contracts.BlogInterfaces;
using OnionApp.Domain.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Concrete.BlogRepositories
{
    public class BlogRepository(AppDbContext _context) : IBlogRepository
    {
        public async Task<List<Blog>> GetLast3BlogsWithAuthorsAsync()
        {
            return await _context.Blogs
                .Include(x => x.Author) 
                .OrderByDescending(x => x.CreatedDate) 
                .Take(3) 
                .ToListAsync();
        }
    }
}
