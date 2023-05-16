using Coursework.Application.Models.GetAllQuery;
using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Recruiters.Queries.GetCandidatesNearbyRecruiter
{
    public class GetCandidatesNearbyRecruiterRequest : IRequest<GetItemsList<Candidate>>
    {
        public Guid UserGID { get; set; }

        public int MaxDistance { get; set; }
    }
}
