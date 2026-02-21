using OnionApp.Application.Contracts.CategoryInterfaces;
using OnionApp.Domain.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Concrete.CategoryRepositories
{
    public class CategoryRepository(AppDbContext _context) : GenericRepository<Category>(_context), ICategoryRepository
    {
    }
}
