namespace Coursework.Domain.Entities
{
    public class User
    {
        public User()
        {
            Candidates = new HashSet<Candidate>();
            Recruiters = new HashSet<Recruiter>();
        }

        public Guid GID { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual ICollection<Recruiter> Recruiters { get; set; }
    }
}
