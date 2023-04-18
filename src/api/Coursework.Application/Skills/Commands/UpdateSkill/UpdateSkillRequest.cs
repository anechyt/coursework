using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Skills.Commands.UpdateSkill
{
    public class UpdateSkillRequest : ICommand<Skill>
    {
        public Guid GID { get; set; }

        public string Name { get; set; }
    }
}
