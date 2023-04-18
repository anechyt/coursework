using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.VacancyStatuses.Commands.CreateVacancyStatus
{
    public class CreateVacancyStatusRequest : ICommand<VacancyStatus>
    {
        public string Name { get; set; }
    }
}
