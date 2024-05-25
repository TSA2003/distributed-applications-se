using API.Jwt;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using System.Data;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;
        private readonly JwtUtils _jwtUtils;

        public UsersController(UserService service, JwtUtils jwtUtils)
        {
            _service = service;
            _jwtUtils = jwtUtils;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(LoginDto dto)
        {
            try
            {
                var result = await _service.GetByCredentialsAsync(dto.Username, dto.Password);
                result.Token = _jwtUtils.GenerateJwtToken(result);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        
    }
}
