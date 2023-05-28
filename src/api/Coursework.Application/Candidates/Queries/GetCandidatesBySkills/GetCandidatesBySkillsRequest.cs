using Coursework.Application.Candidates.Models;
using Mediator;

namespace Coursework.Application.Candidates.Queries.GetCandidatesBySkills
{
    public class GetCandidatesBySkillsRequest : IRequest<List<CandidateWithScoreResponseModel>>
    {
        public List<string> Skills { get; set; }
    }
}
