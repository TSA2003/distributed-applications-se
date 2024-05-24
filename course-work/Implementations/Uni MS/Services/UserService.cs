using AutoMapper;
using Data.Entities;
using Data.Repositories;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : BaseService<User, UserDto, Guid>
    {
        public UserService(UsersRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<UserDto> GetByCredentialsAsync(string username, string password)
        {
            var entity = await _repository.ReadAsync(e => e.Username == username && e.Password == password);
            var result = ConvertEntityToDto(entity);
            
            return result;
        }
    }
}
