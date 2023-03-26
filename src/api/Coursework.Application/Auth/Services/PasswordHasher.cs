using Coursework.Application.Auth.Abstract;

namespace Coursework.Application.Auth.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string salt)
        {
            return BCrypt.Net.BCrypt.Verify(password, salt);
        }
    }
}
