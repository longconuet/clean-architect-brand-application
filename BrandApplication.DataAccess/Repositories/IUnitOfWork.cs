namespace BrandApplication.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
