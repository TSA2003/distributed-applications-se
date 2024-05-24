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
    public class CourseService : BaseService<Course, CourseDto, Guid>
    {
        public CourseService(CoursesRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override CourseDto ConvertEntityToDto(Course entity)
        {
            var dto = base.ConvertEntityToDto(entity);
            dto.TeacherFirstName = entity.Teacher.FirstName;
            dto.TeacherLastName = entity.Teacher.LastName;

            return dto;
        }

        public override Course ConvertDtoToEntity(CourseDto dto)
        {
            return base.ConvertDtoToEntity(dto);
        }
    }
}
