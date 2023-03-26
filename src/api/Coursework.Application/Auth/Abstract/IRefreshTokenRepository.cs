using Coursework.Domain.Entities;

namespace Coursework.Application.Auth.Abstract
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByTokenAsync(string token);

        Task Create(RefreshToken refreshToken);

        Task DeleteAsync(Guid refreshTokenGID);

        Task DeleteAllAsync(Guid userGID);
    }
}
