using Coursework.Application.Infrastructure.Mapper;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;

namespace Coursework.Application.Skills.Commands.CreateSkill
{
    public class CreateSkillHandler : ICommandHandler<CreateSkillRequest, Skill>
    {
        private readonly CoursworkContext _context;

        public CreateSkillHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Skill> Handle(CreateSkillRequest command, CancellationToken cancellationToken)
        {
            var mapper = new CourseworkMapper();

            var skill = mapper.CreateSkillCommandMapper(command);

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync(cancellationToken);

            return skill;
        }
    }
}
