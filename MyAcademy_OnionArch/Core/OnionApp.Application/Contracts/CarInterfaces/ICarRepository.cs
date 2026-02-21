using OnionApp.Domain.Entities;

namespace OnionApp.Application.Contracts.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsWithBrandsAsync();
        Task<Car> GetCarByIdWithBrandAsync(int id);
    }
}
