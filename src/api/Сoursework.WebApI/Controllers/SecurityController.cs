using Coursework.Application.Auth.Abstract;
using Coursework.Application.Auth.Models;
using Coursework.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Сoursework.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityRepository _securityRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public SecurityController(IPasswordHasher passwordHasher,
            IUserRepository userRepository,
            ISecurityRepository securityRepository,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _securityRepository = securityRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        [Route("/login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await _userRepository.GetByEmailAsync(model.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            bool isCorrectPassword = _passwordHasher.VerifyPassword(model.Password, user.Password);

            if (!isCorrectPassword)
            {
                return Unauthorized();
            }

            var response = await _securityRepository.Authenticate(user);

            return Ok(response);
        }

        [Route("/register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registrationUser = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Role = model.Role
            };

            await _securityRepository.Registration(registrationUser);

            return Ok();
        }

        [Route("/refresh")]
        [HttpPost]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RefreshToken refreshTokenDTO = await _refreshTokenRepository.GetByTokenAsync(model.Token);

            if (refreshTokenDTO == null)
            {
                return BadRequest(ModelState);
            }

            await _refreshTokenRepository.DeleteAsync(refreshTokenDTO.UserGID);

            User user = await _userRepository.GetByIdAsync(refreshTokenDTO.UserGID);

            if (user == null)
            {
                return NotFound();
            }

            var response = await _securityRepository.Authenticate(user);

            return Ok(response);

        }

        [Authorize]
        [Route("/logout")]
        [HttpDelete]
        public async Task<ActionResult> Logout()
        {
            string rawUserGID = HttpContext.User.FindFirstValue("UserGID");

            if (!Guid.TryParse(rawUserGID, out Guid userGID))
            {
                return Unauthorized();
            }

            await _refreshTokenRepository.DeleteAllAsync(userGID);

            return NoContent();
        }
    }
}
