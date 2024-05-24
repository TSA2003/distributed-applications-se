using API.Attributes;
using AutoMapper;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticate]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService _service;
        private readonly IMapper _mapper;

        public CoursesController(CourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllAsync()
        {
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
        public async Task<IActionResult> CreateAsync(CourseDto dto)
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
        public async Task<IActionResult> UpdateAsync(CourseDto dto)
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
