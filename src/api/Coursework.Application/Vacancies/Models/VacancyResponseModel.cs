using Coursework.Domain.Entities;

namespace Coursework.Application.Vacancies.Models
{
    public class VacancyResponseModel
    {
        public Guid GID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public string Location { get; set; }

        public List<Skill> Skills { get; set; }

        public string VacancyStatusName { get; set; }

        public string RecruiterFirstName { get; set; }

        public string RecruiterLastName { get; set; }

        public string RecruiterPhoneNumber { get; set; }
    }
}
