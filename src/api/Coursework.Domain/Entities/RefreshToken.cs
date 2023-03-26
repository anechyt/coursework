namespace Coursework.Domain.Entities
{
    public class RefreshToken
    {
        public Guid RefreshTokenGID { get; set; }

        public string Token { get; set; }

        public Guid UserGID { get; set; }

        public virtual User User { get; set; }
    }
}
