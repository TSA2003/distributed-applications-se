using AutoMapper;
using Data.Entities;
using Data.Repositories;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services
{
    public class StudentService : BaseService<Student, StudentDto, Guid>
    {
        public StudentService(StudentsRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<StudentDto>> ReadAllByFilterAsync(string firstName, string? lastName, int? page)
        {
            //Expression<Func<Student, bool>> a = (x) => x.FirstName == "A";

            //ParameterExpression param1 = Expression.Parameter(typeof(Student), "entity");
            //BinaryExpression sumBody = Expression.Add(param1, param2);
            //var b = Expression.AndAlso(a, a);
            //b = Expression.AndAlso(b, a);
            //var c = Expression.Lambda<Func<Student, bool>>(b, param1);
            //_service.ReadAllAsync(a);

            Expression<Func<Student, bool>> query = x => x == x;
            

            if (firstName is not null)
            {
                Expression<Func<Student, bool>> query2 = x => x.FirstName.Contains(firstName);
                var param = Expression.Parameter(typeof(Student), "x");
                var body = Expression.AndAlso(
                    Expression.Invoke(query, param), Expression.Invoke(query2, param));
                query = Expression.Lambda<Func<Student, bool>>(body, param);
            }

            if (lastName is not null)
            {
                Expression<Func<Student, bool>> query2 = x => x.LastName.Contains(lastName);
                var param = Expression.Parameter(typeof(Student), "x");
                var body = Expression.AndAlso(
                    Expression.Invoke(query, param), Expression.Invoke(query2, param));
                query = Expression.Lambda<Func<Student, bool>>(body, param);
            }

            if (page is not null)
            {
                
            }

            var data = await _repository.ReadAllAsync(query);

            return data.Select(x => ConvertEntityToDto(x)).ToList();
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
