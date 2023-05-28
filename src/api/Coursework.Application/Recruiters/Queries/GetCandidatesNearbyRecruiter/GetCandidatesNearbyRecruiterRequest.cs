using Coursework.Application.Candidates.Models;
using Coursework.Application.Models.GetAllQuery;
using Mediator;

namespace Coursework.Application.Recruiters.Queries.GetCandidatesNearbyRecruiter
{
    public class GetCandidatesNearbyRecruiterRequest : IRequest<GetItemsList<CandidateResponseModel>>
    {
        public Guid UserGID { get; set; }

        public int MaxDistance { get; set; }
    }
}
