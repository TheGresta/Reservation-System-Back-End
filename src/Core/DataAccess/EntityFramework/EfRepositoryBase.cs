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

                int row = await context.SaveChangesAsync();
                if (row > 0)
                    return entity;

                return null;
            }
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                await context.AddRangeAsync(entities);

                int row = await context.SaveChangesAsync();

                //todo: check false
                if (row == entities.Count)
                    return true;
                return false;
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                EntityEntry entityEntry = context.Remove(entity);

                int row = await context.SaveChangesAsync();
                if (row > 0)
                    return entity;

                return null;
            }
        }

        public async Task<List<TEntity>> GetAllAsync(bool tracking = true)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> data = context.Set<TEntity>().AsQueryable();

                data = data.OrderBy(x => x.Id);
                data = data.Where(x => x.DeletedDate.HasValue == false);

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

                data = data.OrderBy(x => x.Id);
                data = data.Where(x => x.DeletedDate.HasValue == false);

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
            using (var context = new TContext())
            {
                EntityEntry entityEntry = context.Set<TEntity>().Update(entity);

                int row = await context.SaveChangesAsync();
                if (row > 0)
                    return entity;

                return null;
            }
        }
    }
}
