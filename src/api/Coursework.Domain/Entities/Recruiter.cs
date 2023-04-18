namespace Coursework.Domain.Entities
{
    public class Recruiter
    {
        public Recruiter()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public Guid GID { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Biography { get; set; } = null!;

        public string Location { get; set; } = null!;

        public Guid UserGID { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }

    }
}
