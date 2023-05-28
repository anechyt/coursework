using Mediator;

namespace Coursework.Application.Vacancies.Commands.DeleteVacancy
{
    public class DeleteVacancyRequest : ICommand<Guid>
    {
        public Guid GID { get; set; }
    }
}
