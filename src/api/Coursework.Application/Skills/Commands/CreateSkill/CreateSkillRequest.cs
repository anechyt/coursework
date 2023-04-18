using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Skills.Commands.CreateSkill
{
    public class CreateSkillRequest : ICommand<Skill>
    {
        public string Name { get; set; }
    }
}
