using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Candidates.Queries.GetCandidateByUserGID
{
    public class GetCandidateByUserGIDRequest : IRequest<Candidate>
    {
        public Guid UserGID { get; set; }
    }
}
