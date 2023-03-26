namespace Coursework.Domain.Entities
{
    public class Candidate
    {
        public Guid GID { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? Biography { get; set; }

        public string ResumeUrl { get; set; } = null!;

        public Guid UserGID { get; set; }

        public virtual User User { get; set; }
    }
}
