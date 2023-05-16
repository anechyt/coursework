using Coursework.Application.Infrastructure.Mapper;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;

namespace Coursework.Application.Vacancies.Commands.CreateVacancy
{
    public class CreateVacancyHandler : ICommandHandler<CreateVacancyRequest, Vacancy>
    {
        private readonly CoursworkContext _context;

        public CreateVacancyHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Vacancy> Handle(CreateVacancyRequest command, CancellationToken cancellationToken)
        {
            var mapper = new CourseworkMapper();

            var candidate = mapper.CreateVacancyCommandMapper(command);

            _context.Vacancies.Add(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return candidate;
        }
    }
}
