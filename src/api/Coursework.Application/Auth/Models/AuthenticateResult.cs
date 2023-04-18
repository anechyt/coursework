namespace Coursework.Application.Auth.Models
{
    public class AuthenticateResult
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpirationTime { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public string UserGID { get; set; }
    }
}
