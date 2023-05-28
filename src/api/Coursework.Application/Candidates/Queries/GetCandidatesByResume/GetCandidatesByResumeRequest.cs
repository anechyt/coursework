using Coursework.Application.Candidates.Models;
using Mediator;

namespace Coursework.Application.Candidates.Queries.GetCandidatesByResume
{
    public class GetCandidatesByResumeRequest : IRequest<List<CandidateWithScoreResponseModel>>
    {
        public List<string> Resume { get; set; }
    }
}
