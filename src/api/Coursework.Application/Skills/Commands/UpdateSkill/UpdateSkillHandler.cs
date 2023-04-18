using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Skills.Commands.UpdateSkill
{
    public class UpdateSkillHandler : ICommandHandler<UpdateSkillRequest, Skill>
    {
        private readonly CoursworkContext _context;

        public UpdateSkillHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Skill> Handle(UpdateSkillRequest command, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (skill is null)
                throw new Exception($"Skill with Guid {command.GID} not found");

            skill.Name = command.Name;

            _context.Skills.Update(skill);
            await _context.SaveChangesAsync(cancellationToken);

            return skill;
        }
    }
}
