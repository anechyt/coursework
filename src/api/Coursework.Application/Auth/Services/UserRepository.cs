using Coursework.Application.Auth.Abstract;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Auth.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CoursworkContext _coursworkContext;

        public UserRepository(CoursworkContext coursworkContext)
        {
            _coursworkContext = coursworkContext;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _coursworkContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> GetByIdAsync(Guid gid)
        {
            return await _coursworkContext.Users.FirstOrDefaultAsync(user => user.GID == gid);
        }
    }
}
