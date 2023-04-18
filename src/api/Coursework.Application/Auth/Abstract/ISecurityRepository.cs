using Coursework.Application.Auth.Models;
using Coursework.Domain.Entities;

namespace Coursework.Application.Auth.Abstract
{
    public interface ISecurityRepository
    {
        Task<AuthenticateResult> Authenticate(User user);
        Task<RegisterResult> Registration(User user);
    }
}
