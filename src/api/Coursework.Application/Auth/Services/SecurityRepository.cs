using Coursework.Application.Auth.Abstract;
using Coursework.Application.Auth.Models;
using Coursework.Application.Auth.TokenGenerators;
using Coursework.Domain.Entities;
using Coursework.Persistence;

namespace Coursework.Application.Auth.Services
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly CoursworkContext _coursworkContext;
        private readonly IUserRepository _userRepository;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IPasswordHasher _passwordHasher;

        public SecurityRepository(CoursworkContext coursworkContext,
            IUserRepository userRepository,
            AccessTokenGenerator accessTokenGenerator,
            RefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenRepository refreshTokenRepository,
            IPasswordHasher passwordHasher)
        {
            _coursworkContext = coursworkContext;
            _userRepository = userRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticateResult> Authenticate(User user)
        {
            AccessToken accessToken = _accessTokenGenerator.GenerateToken(user);
            string refreshToken = _refreshTokenGenerator.GenerateToken();
            var refreshTokenDto = new RefreshToken
            {
                Token = refreshToken,
                UserGID = user.GID
            };

            await _refreshTokenRepository.Create(refreshTokenDto);
            return new AuthenticateResult
            {
                AccessToken = accessToken.Value,
                AccessTokenExpirationTime = accessToken.ExpirationTime,
                RefreshToken = refreshToken
            };
        }

        public async Task Registration(User user)
        {
            var emailAlredyExist = await _userRepository.GetByEmailAsync(user.Email);
            if (emailAlredyExist != null)
                throw new System.Exception("Error Email");

            var passwordHash = _passwordHasher.HashPassword(user.Password);

            var newUser = new User
            {
                Email = user.Email,
                Password = passwordHash,
                Role = user.Role
            };

            await _coursworkContext.Users.AddAsync(newUser);
            await _coursworkContext.SaveChangesAsync();
        }
    }
}
