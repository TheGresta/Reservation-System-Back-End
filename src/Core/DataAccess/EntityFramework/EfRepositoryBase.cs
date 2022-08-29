using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                EntityEntry entityEntry = await context.AddAsync(entity);
                if (entityEntry.State == EntityState.Added)
                    return entity;

                return null;
            }
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                await context.AddRangeAsync(entities);
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                using (var context = new TContext())
                {
                    EntityEntry entityEntry = context.Remove(entity);
                    if (entityEntry.State == EntityState.Deleted)
                        return entity;

                    return null;
                }
            });
        }

        public async Task<List<TEntity>> GetAllAsync(bool tracking = true)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> data = context.Set<TEntity>().AsQueryable();

                if (tracking == false)
                    data.AsNoTracking();

                data.OrderBy(x => x.Id);

                return await data.ToListAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> data = context.Set<TEntity>().AsQueryable();

                if (tracking == false)
                    data.AsNoTracking();

                data.Where(predicate);
                data.OrderBy(x => x.Id);

                return await data.ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> data = context.Set<TEntity>().AsQueryable();

                if (tracking == false)
                    data.AsNoTracking();

                TEntity entity = await data.SingleOrDefaultAsync(predicate);
                return entity;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                using (var context = new TContext())
                {
                    EntityEntry entityEntry = context.Update(entity);
                    if (entityEntry.State == EntityState.Modified)
                        return entity;

                    return null;
                }
            });
        }
    }
}
