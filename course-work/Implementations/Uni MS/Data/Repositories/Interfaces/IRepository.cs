using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity where TKey : struct
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(TKey key);
        Task<TEntity> ReadAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> ReadAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task UpdateAsync(TEntity entity, TKey key);
        Task DeleteAsync(TKey key);
    }
}
