using AutoMapper;
using Data.Entities;
using Data.Repositories;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<TEntity, TDto, TKey> : IService<TEntity, TDto, TKey> where TEntity : BaseEntity where TDto : BaseDto where TKey : struct
    {
        protected readonly BaseRepository<TEntity, TKey> _repository;
        protected readonly IMapper _mapper;

        public BaseService(BaseRepository<TEntity, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.CreateAsync(entity);
        }

        public virtual async Task<TDto> ReadAsync(TKey key)
        {
            var entity = await _repository.ReadAsync(key);

            return ConvertEntityToDto(entity);
        }

        public virtual async Task<ICollection<TDto>> ReadAllAsync()
        {
            var entities = await _repository.ReadAllAsync();
            return entities.Select(e => ConvertEntityToDto(e)).ToList();
        }

        public virtual async Task UpdateAsync(TDto dto, TKey key)
        {
            var entity = ConvertDtoToEntity(dto);
            await _repository.UpdateAsync(entity, key);
        }

        public virtual async Task DeleteAsync(TKey key)
        {
            await _repository.DeleteAsync(key);
        }

        public virtual TDto ConvertEntityToDto(TEntity entity)
        {
            var dto = _mapper.Map<TDto>(entity);
            return dto;
        }

        public virtual TEntity ConvertDtoToEntity(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return entity;
        }
    }
}
