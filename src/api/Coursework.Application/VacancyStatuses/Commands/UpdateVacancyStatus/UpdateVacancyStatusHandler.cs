using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.VacancyStatuses.Commands.UpdateVacancyStatus
{
    public class UpdateVacancyStatusHandler : ICommandHandler<UpdateVacancyStatusRequest, VacancyStatus>
    {
        private readonly CoursworkContext _context;

        public UpdateVacancyStatusHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<VacancyStatus> Handle(UpdateVacancyStatusRequest command, CancellationToken cancellationToken)
        {
            var vacnacyStatus = await _context.VacancyStatuses.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (vacnacyStatus is null)
                throw new Exception($"VacnacyStatus with Guid {command.GID} not found");

            vacnacyStatus.Name = command.Name;

            _context.VacancyStatuses.Update(vacnacyStatus);
            await _context.SaveChangesAsync(cancellationToken);

            return vacnacyStatus;
        }
    }
}
