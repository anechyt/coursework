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

            var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var vacancy = mapper.CreateVacancyCommandMapper(command);
                var skills = mapper.SkillModelMapper(command.Skills);

                _context.Skills.AddRange(skills);
                _context.Vacancies.Add(vacancy);

                foreach (var skill in skills)
                {
                    var vacancySkill = new VacancySkill
                    {
                        VacancyGID = vacancy.GID,
                        SkillGID = skill.GID,
                        Skill = skill,
                        Vacancy = vacancy
                    };

                    _context.VacancySkills.Add(vacancySkill);
                }
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return vacancy;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw ex;
            }
        }
    }
}
