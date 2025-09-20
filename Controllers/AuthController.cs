using AuthFinance.Context;
using AuthFinance.DTO;
using AuthFinance.Models;
using AuthFinance.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthFinance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController :ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO request)
        {
            if (await _context.Users.AnyAsync(x => x.Username == request.Username))
                return BadRequest("O usuário ja existe");

            if(!UsernameValidator.ValidUsername(request.Username))
                return BadRequest("Username inválido. O username deve começar com uma letra, use pelo menos 3 caracteres e apenas letras ou números.");

            if (!PasswordValidator.StrongPassword(request.Password))
                return BadRequest("Senha fraca. Use letras maiúsculas, mínusculas, números e simbolos e pelo menos 8 caracteres.");

            var user = new User
            {
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { user.Id, user.Username });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == request.Password);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return Unauthorized("Usuário ou senha inválidos.");

            var token = _tokenService.GenerateToken(user.Username);
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var username = User.Identity?.Name;
            return Ok(new
            {
                Username = username
            });
        }
    }
}
