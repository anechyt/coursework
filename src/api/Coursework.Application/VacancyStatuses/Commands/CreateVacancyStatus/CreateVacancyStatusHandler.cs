using Coursework.Application.Infrastructure.Mapper;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;

namespace Coursework.Application.VacancyStatuses.Commands.CreateVacancyStatus
{
    public class CreateVacancyStatusHandler : ICommandHandler<CreateVacancyStatusRequest, VacancyStatus>
    {
        private readonly CoursworkContext _context;

        public CreateVacancyStatusHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<VacancyStatus> Handle(CreateVacancyStatusRequest command, CancellationToken cancellationToken)
        {
            var mapper = new CourseworkMapper();

            var vacancyStatus = mapper.CreateVacancyStatusCommandMapper(command);

            _context.VacancyStatuses.Add(vacancyStatus);
            await _context.SaveChangesAsync(cancellationToken);

            return vacancyStatus;
        }
    }
}
