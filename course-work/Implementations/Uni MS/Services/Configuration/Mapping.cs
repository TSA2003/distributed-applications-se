using Data.Entities;
using AutoMapper;
using Services.DTOs;

namespace Services.Configuration
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
