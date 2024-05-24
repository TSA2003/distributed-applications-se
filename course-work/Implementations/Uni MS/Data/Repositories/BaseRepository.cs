using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity where TKey : struct
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public virtual async Task CreateAsync(TEntity item)
        {
            context.Set<TEntity>().Add(item);
            await context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> ReadAsync(TKey id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);

            if (entity is null)
            {
                throw new ArgumentException($"Entity of type {typeof(TEntity)} is not found");
            }

            return entity;
        }

        public virtual async Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {


            var entity = await context.Set<TEntity>().SingleOrDefaultAsync(predicate);

            if (entity is null)
            {
                throw new ArgumentException($"Entity of type {typeof(TEntity)} is not found");
            }

            return entity;
        }

        public virtual async Task<ICollection<TEntity>> ReadAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (predicate is not null)
            {
                query = query.Where(predicate).AsQueryable();
            }

            return await query.ToListAsync();
        }

        public virtual async Task UpdateAsync(TEntity item, TKey id)
        {
            TEntity itemToUpdate = await ReadAsync(id);
            context.Entry(itemToUpdate).CurrentValues.SetValues(item);
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            TEntity itemToRemove = await ReadAsync(id);
            context.Set<TEntity>().Remove(itemToRemove);
            await context.SaveChangesAsync();
        }
    }
}
