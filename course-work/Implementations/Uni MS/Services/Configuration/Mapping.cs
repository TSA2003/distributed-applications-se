using Data.Entities;
using AutoMapper;
using Services.DTOs;

namespace Services.Configuration
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
