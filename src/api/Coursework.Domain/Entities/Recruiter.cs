namespace Coursework.Domain.Entities
{
    public class Recruiter
    {
        public Guid GID { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ProfileImageUrl { get; set; }

        public Guid UserGID { get; set; }

        public virtual User User { get; set; }

    }
}
