namespace Coursework.Domain.Entities
{
    public class AccessToken
    {
        public string Value { get; set; }

        public DateTime ExpirationTime { get; set; }
    }
}
