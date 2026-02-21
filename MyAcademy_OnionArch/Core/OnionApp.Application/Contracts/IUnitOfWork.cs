namespace OnionApp.Application.Contracts
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();

    }
}
