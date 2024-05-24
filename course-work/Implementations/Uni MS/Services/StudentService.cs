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
    public class StudentService : BaseService<Student, StudentDto, Guid>
    {
        public StudentService(StudentsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override StudentDto ConvertEntityToDto(Student entity)
        {
            var dto = base.ConvertEntityToDto(entity);
            dto.CourseName = entity.Course.Name;

            return dto;
        }

        public override Student ConvertDtoToEntity(StudentDto dto)
        {
            return base.ConvertDtoToEntity(dto);
        }
    }
}
