using Mediator;

namespace Coursework.Application.Recruiters.Commands.DeleteRecruiter
{
    public class DeleteRecruiterRequest : ICommand<Guid>
    {
        public Guid GID { get; set; }
    }
}
