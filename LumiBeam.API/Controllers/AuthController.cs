using LumiBeam.API.DTOs.Auth;
using LumiBeam.API.Services.Interfaces;
using LumiBeam.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LumiBeam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LumiBeamDbContext _context;
        private readonly IPasswordHasherService _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthController(
            LumiBeamDbContext context,
            IPasswordHasherService passwordHasher,
            ITokenService tokenService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Авторизація співробітника салону за номером телефону та паролем.
        /// </summary>
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Шукаємо користувача за унікальним номером телефону (O(log N) завдяки індексу)
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber, cancellationToken);

            if (user is null)
                return Unauthorized(new { message = "Невірний номер телефону або пароль." });

            // Перевіряємо хеш пароля за допомогою PBKDF2
            bool isPasswordValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash);
            if (!isPasswordValid)
                return Unauthorized(new { message = "Невірний номер телефону або пароль." });

            // Генеруємо JWT токен із клеймами користувача
            var (token, expiresAt) = _tokenService.GenerateToken(user);

            var response = new AuthResponseDto
            {
                Token = token,
                ExpiresAt = expiresAt,
                UserId = user.Id,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };

            return Ok(response);
        }
    }
}
