using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.VacancyStatuses.Commands.UpdateVacancyStatus
{
    public class UpdateVacancyStatusRequest : ICommand<VacancyStatus>
    {
        public Guid GID { get; set; }

        public string Name { get; set; }
    }
}
