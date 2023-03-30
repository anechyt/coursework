namespace Coursework.Domain.Entities
{
    public class VacancyStatus
    {
        public VacancyStatus()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public Guid GID { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
