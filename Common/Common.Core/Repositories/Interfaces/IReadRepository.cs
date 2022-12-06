using Common.Core.Entities;
using System.Linq.Expressions;

namespace Common.Core.Repositories.Interfaces
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAllOrWhere(Expression<Func<T, bool>>? filter, bool tracking = true);
        T GetSingle(Expression<Func<T, bool>>? filter, bool tracking = true);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);
    }
}
