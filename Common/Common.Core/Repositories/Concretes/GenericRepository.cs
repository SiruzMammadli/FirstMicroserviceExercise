using Common.Core.Entities;
using Common.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Core.Repositories.Concretes
{
    public class GenericRepository<T, TContext> : IWriteRepository<T>, IReadRepository<T> where T : BaseEntity where TContext : DbContext, new()
    {
        #region Writing Methods
        public virtual int Add(T entity)
        {
            using TContext dbContext = new();
            dbContext.Set<T>().Add(entity);
            return dbContext.SaveChanges();
        }
        public virtual async Task<int> AddAsync(T entity)
        {
            using TContext dbContext = new();
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }
        public virtual int AddRange(IEnumerable<T> entities)
        {
            using TContext dbContext = new();
            dbContext.Set<T>().AddRange(entities);
            return dbContext.SaveChanges();
        }
        public virtual async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            using TContext dbContext = new();
            await dbContext.Set<T>().AddRangeAsync(entities);
            return await dbContext.SaveChangesAsync();
        }
        public virtual int Delete(T entity)
        {
            using TContext dbContext = new();
            dbContext.Set<T>().Remove(entity);
            return dbContext.SaveChanges();
        }
        public virtual int DeleteById(Guid id)
        {
            using TContext dbContext = new();
            var entity = dbContext.Set<T>().Find(id);
            return Delete(entity);
        }
        public virtual async Task<int> DeleteByIdAsync(Guid id)
        {
            using TContext dbContext = new();
            var entity = await dbContext.Set<T>().FindAsync(id);
            return Delete(entity);
        }
        public virtual int DeleteRange(IEnumerable<T> entities)
        {
            using TContext dbContext = new();
            dbContext.Set<T>().RemoveRange(entities);
            return dbContext.SaveChanges();
        }
        public virtual int Update(T entity)
        {
            using TContext dbContext = new();
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }
        #endregion

        #region Reading Methods
        public virtual IEnumerable<T> GetAllOrWhere(Expression<Func<T, bool>>? filter, bool tracking = true)
        {
            using TContext dbContext = new();
            IQueryable<T> query = dbContext.Set<T>().AsQueryable();

            if (filter is not null) query = query.Where(filter);

            if (!tracking) query = query.AsNoTracking();

            return query;

        }
        public virtual async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            using TContext dbContext = new();
            var found = await dbContext.Set<T>().FindAsync(id);

            if (!tracking) dbContext.Entry(found).State = EntityState.Detached;

            return found;
        }

        public virtual T GetSingle(Expression<Func<T, bool>>? filter, bool tracking = true)
        {
            using TContext dbContext = new();
            var query = dbContext.Set<T>().AsQueryable();

            if (filter is not null) query = query.Where(filter);

            if (!tracking) query = query.AsNoTracking();

            return query.FirstOrDefault();
        }
        #endregion
    }
}
