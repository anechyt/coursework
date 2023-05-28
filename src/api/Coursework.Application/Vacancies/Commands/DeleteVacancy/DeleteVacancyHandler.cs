using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Vacancies.Commands.DeleteVacancy
{
    public class DeleteVacancyHandler : ICommandHandler<DeleteVacancyRequest, Guid>
    {
        private readonly CoursworkContext _context;

        public DeleteVacancyHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Guid> Handle(DeleteVacancyRequest command, CancellationToken cancellationToken)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (vacancy is null)
                throw new Exception($"Vacancy with Guid {command.GID} not found");

            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync(cancellationToken);

            return command.GID;
        }
    }
}
