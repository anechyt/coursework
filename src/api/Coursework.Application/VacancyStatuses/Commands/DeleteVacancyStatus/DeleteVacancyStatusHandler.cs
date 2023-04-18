using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.VacancyStatuses.Commands.DeleteVacancyStatus
{
    public class DeleteVacancyStatusHandler : ICommandHandler<DeleteVacancyStatusRequest, Guid>
    {
        private readonly CoursworkContext _context;

        public DeleteVacancyStatusHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Guid> Handle(DeleteVacancyStatusRequest command, CancellationToken cancellationToken)
        {
            var vacancyStatus = await _context.VacancyStatuses.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (vacancyStatus is null)
                throw new Exception($"VacancyStatus with Guid {command.GID} not found");

            _context.VacancyStatuses.Remove(vacancyStatus);
            await _context.SaveChangesAsync(cancellationToken);

            return vacancyStatus.GID;
        }
    }
}
