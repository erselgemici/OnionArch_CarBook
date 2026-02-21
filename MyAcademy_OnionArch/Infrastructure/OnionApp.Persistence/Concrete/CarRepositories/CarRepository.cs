using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Contracts.CarInterfaces;
using OnionApp.Domain.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Concrete.CarRepositories
{
    public class CarRepository(AppDbContext _context) : ICarRepository
    {
        public async Task<List<Car>> GetCarsWithBrandsAsync()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }

        public async Task<Car> GetCarByIdWithBrandAsync(int id)
        {
            return await _context.Cars.Include(x => x.Brand).FirstOrDefaultAsync(x => x.CarID == id);
        }
    }
}
