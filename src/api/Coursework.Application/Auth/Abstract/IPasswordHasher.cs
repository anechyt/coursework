namespace Coursework.Application.Auth.Abstract
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string password, string salt);
    }
}
