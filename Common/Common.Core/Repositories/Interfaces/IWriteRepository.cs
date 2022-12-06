using Common.Core.Entities;

namespace Common.Core.Repositories.Interfaces
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        Task<int> AddAsync(T entity);
        int Add(T entity);
        Task<int> AddRangeAsync(IEnumerable<T> entities);
        int AddRange(IEnumerable<T> entities);

        int Update(T entity);

        int Delete(T entity);
        int DeleteRange(IEnumerable<T> entities);
        Task<int> DeleteByIdAsync(Guid id);
        int DeleteById(Guid id);
    }
}
