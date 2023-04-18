namespace Coursework.Application.Auth.Models
{
    public class RegisterResult
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpirationTime { get; set; }

        public string UserGID { get; set; }

        public string Role { get; set; }
    }
}
