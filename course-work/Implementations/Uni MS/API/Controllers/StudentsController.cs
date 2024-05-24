using API.Attributes;
using AutoMapper;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using System.Linq.Expressions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticate]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;
        private readonly IMapper _mapper;

        public StudentsController(StudentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllAsync()
        {
            //Expression<Func<Student, bool>> a = (x) => x.FirstName == "A";

            //ParameterExpression param1 = Expression.Parameter(typeof(Student), "entity");
            //BinaryExpression sumBody = Expression.Add(param1, param2);
            //var b = Expression.AndAlso(a, a);
            //b = Expression.AndAlso(b, a);
            //var c = Expression.Lambda<Func<Student, bool>>(b, param1);
            //_service.ReadAllAsync(a);
            var result = await _service.ReadAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadAsync(Guid id)
        {
            try
            {
                var result = await _service.ReadAsync(id);

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _service.CreateAsync(dto);

                return CreatedAtAction("Create", dto);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(dto, dto.Id);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }

            return NoContent();
        }
    }
}
