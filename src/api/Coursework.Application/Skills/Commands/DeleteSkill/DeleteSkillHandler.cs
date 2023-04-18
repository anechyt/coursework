using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Skills.Commands.DeleteSkill
{
    public class DeleteSkillHandler : ICommandHandler<DeleteSkillRequest, Guid>
    {
        private readonly CoursworkContext _context;

        public DeleteSkillHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Guid> Handle(DeleteSkillRequest command, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (skill is null)
                throw new Exception($"Skill with Guid {command.GID} not found");

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync(cancellationToken);

            return skill.GID;
        }
    }
}
