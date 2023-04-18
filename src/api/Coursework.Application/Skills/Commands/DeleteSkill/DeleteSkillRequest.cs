using Mediator;

namespace Coursework.Application.Skills.Commands.DeleteSkill
{
    public class DeleteSkillRequest : ICommand<Guid>
    {
        public Guid GID { get; set; }
    }
}
