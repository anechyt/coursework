using Coursework.Application.Candidates.Models;
using Mediator;

namespace Coursework.Application.Candidates.Queries.GetCandidatesByBio
{
    public class GetCandidatesByBioRequest : IRequest<List<CandidateWithScoreResponseModel>>
    {
        public List<string> Bio { get; set; }
    }
}
