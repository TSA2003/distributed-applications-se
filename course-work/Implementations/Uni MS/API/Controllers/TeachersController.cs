using API.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticate]
    public class TeachersController : ControllerBase
    {
        private TeacherService _service;

        public TeachersController(TeacherService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> ReadAllAsync()
        {
            var result = _service.ReadAllAsync();
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAsync(TeacherDto dto)
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
        public async Task<IActionResult> UpdateAsync([FromBody] TeacherDto dto)
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
        public async Task<IActionResult> Delete(Guid id)
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
