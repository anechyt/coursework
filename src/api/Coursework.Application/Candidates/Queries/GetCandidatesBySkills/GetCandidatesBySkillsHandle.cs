using Coursework.Application.Candidates.Models;
using Coursework.Domain.Entities;
using Coursework.Infrastructure.PartialSearch.Abstract;
using Coursework.Infrastructure.PartialSearch.Models;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Candidates.Queries.GetCandidatesBySkills
{
    public class GetCandidatesBySkillsHandle : IRequestHandler<GetCandidatesBySkillsRequest, List<CandidateWithScoreResponseModel>>
    {
        private readonly CoursworkContext _context;
        private readonly IPartialSearchService _partialSearchService;

        public GetCandidatesBySkillsHandle(CoursworkContext context,
            IPartialSearchService partialSearchService)
        {
            _context = context;
            _partialSearchService = partialSearchService;
        }

        public async ValueTask<List<CandidateWithScoreResponseModel>> Handle(GetCandidatesBySkillsRequest request, CancellationToken cancellationToken)
        {
            var candidates = await (
                    from candidate in _context.Candidates
                    join users in _context.Users on candidate.UserGID equals users.GID
                    join candidateSkill in _context.CandidateSkills on candidate.GID equals candidateSkill.CandidateGID
                    join skill in _context.Skills on candidateSkill.SkillGID equals skill.GID
                    group skill by candidate into g
                    select new CandidateResponseModel
                    {
                        GID = g.Key.GID,
                        FirstName = g.Key.FirstName,
                        LastName = g.Key.LastName,
                        PhoneNumber = g.Key.PhoneNumber,
                        Biography = g.Key.Biography,
                        Resume = g.Key.Resume,
                        Location = g.Key.Location,
                        UserGID = g.Key.UserGID,
                        Skills = g.ToList()
                    }
                ).ToListAsync(cancellationToken);

            var searchedResult = new List<CandidateWithScoreResponseModel>();

            foreach( var candidate in candidates )
            {
                var searchModel = new PartialSearchModel
                {
                    SearchList = new List<string>(candidate.Skills.Select(s => s.Name)),
                    Requests = new List<string>(request.Skills)
                };

                var searchScoreResult = _partialSearchService.PartialSearch(searchModel);

                var searchedCandidate = new CandidateWithScoreResponseModel
                {
                    GID = candidate.GID,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    PhoneNumber = candidate.PhoneNumber,
                    Biography = candidate.Biography,
                    Resume = candidate.Resume,
                    Location = candidate.Location,
                    Score = searchScoreResult,
                    UserGID = candidate.UserGID,
                    Skills = candidate.Skills
                };

                searchedResult.Add(searchedCandidate);
            }

            return searchedResult.OrderByDescending(c => c.Score).ToList();
        }
    }
}
