using Mediator;

namespace Coursework.Application.VacancyStatuses.Commands.DeleteVacancyStatus
{
    public class DeleteVacancyStatusRequest : ICommand<Guid>
    {
        public Guid GID { get; set; }
    }
}
