using Data.Entities;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IService<TEntity, TDto, TKey> where TEntity : BaseEntity where TDto : BaseDto where TKey : struct
    {
        Task CreateAsync(TDto dto);
        Task<TDto> ReadAsync(TKey key);
        Task<ICollection<TDto>> ReadAllAsync();
        Task UpdateAsync(TDto dto, TKey key);
        Task DeleteAsync(TKey key);
        TDto ConvertEntityToDto(TEntity entity);
        TEntity ConvertDtoToEntity(TDto dto);

    }
}
