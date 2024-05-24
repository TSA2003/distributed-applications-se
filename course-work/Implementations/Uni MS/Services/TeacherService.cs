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
    public class TeacherService : BaseService<Teacher, TeacherDto, Guid>
    {
        public TeacherService(TeachersRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
