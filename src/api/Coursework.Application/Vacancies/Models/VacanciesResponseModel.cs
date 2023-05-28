using Coursework.Domain.Entities;

namespace Coursework.Application.Vacancies.Models
{
    public class VacanciesResponseModel
    {
        public Guid GID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public string Location { get; set; }

        public List<Skill> Skills { get; set; }

        public Guid VacancyStatusGID { get; set; }

        public Guid RecruiterGID { get; set; }
    }
}
