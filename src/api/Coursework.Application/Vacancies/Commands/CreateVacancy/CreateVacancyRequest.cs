using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Vacancies.Commands.CreateVacancy
{
    public class CreateVacancyRequest : ICommand<Vacancy>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public string Location { get; set; }

        public List<string> Skills { get; set; }

        public string VacancyStatusGID { get; set; }

        public string RecruiterGID { get; set; }
    }
}
