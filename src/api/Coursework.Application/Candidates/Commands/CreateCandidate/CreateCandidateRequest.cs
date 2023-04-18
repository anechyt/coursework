using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateRequest : ICommand<Candidate>
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Biography { get; set; } = null!;

        public string Resume { get; set; } = null!;

        public string Location { get; set; } = null!;

        public Guid UserGID { get; set; }
    }
}
