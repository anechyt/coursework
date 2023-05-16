namespace Coursework.Domain.Entities
{
    public class Vacancy
    {
        public Guid GID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public string Location { get; set; }

        public List<string> Skills { get; set; }

        public Guid VacancyStatusGID { get; set; }

        public Guid RecruiterGID { get; set; }

        public VacancyStatus VacancyStatus { get; set; }

        public Recruiter Recruiter { get; set; }
    }
}
