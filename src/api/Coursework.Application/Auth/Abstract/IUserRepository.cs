using Coursework.Domain.Entities;

namespace Coursework.Application.Auth.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid gid);
    }
}
