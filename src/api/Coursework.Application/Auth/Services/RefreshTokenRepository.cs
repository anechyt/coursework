using Coursework.Application.Auth.Abstract;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Auth.Services
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly CoursworkContext _coursworkContext;

        public RefreshTokenRepository(CoursworkContext coursworkContext)
        {
            _coursworkContext = coursworkContext;
        }

        public async Task Create(RefreshToken refreshToken)
        {
            await _coursworkContext.RefreshTokens.AddAsync(refreshToken);
            await _coursworkContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(Guid userGID)
        {
            IEnumerable<RefreshToken> refreshTokens = await _coursworkContext.RefreshTokens
                .Where(t => t.UserGID == userGID)
                .ToListAsync();

            _coursworkContext.RefreshTokens.RemoveRange(refreshTokens);
            await _coursworkContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid refreshTokenGID)
        {
            var result = await _coursworkContext.RefreshTokens.FindAsync(refreshTokenGID);
            _coursworkContext.RefreshTokens.Remove(result);
            await _coursworkContext.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _coursworkContext.RefreshTokens.FirstAsync(t => t.Token == token);
        }
    }
}
