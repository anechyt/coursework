using Mediator;

namespace Coursework.Application.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateRequest : ICommand<Guid>
    {
        public Guid GID { get; set; }
    }
}
