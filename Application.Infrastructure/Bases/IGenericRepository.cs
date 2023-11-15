namespace Application.Infrastructure.Bases
{
    public interface IGenericRepository<T> where T : class
    {



        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsNoTrackingAsync(int id);
        Task SaveChangesAsync();
        //ApplicationDBContext BeginTransaction();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        void Commit();
        void RollBack();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);

    }
}
