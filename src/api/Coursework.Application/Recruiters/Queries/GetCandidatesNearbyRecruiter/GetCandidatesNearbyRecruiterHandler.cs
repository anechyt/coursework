using Coursework.Application.Candidates.Models;
using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.NearbySearch.Abstract;
using Coursework.Application.NearbySearch.Models;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Recruiters.Queries.GetCandidatesNearbyRecruiter
{
    public class GetCandidatesNearbyRecruiterHandler : IRequestHandler<GetCandidatesNearbyRecruiterRequest, GetItemsList<CandidateResponseModel>>
    {
        private readonly CoursworkContext _context;
        private readonly INearbySearchService _nearbySearchService;

        public GetCandidatesNearbyRecruiterHandler(CoursworkContext context, INearbySearchService nearbySearchService)
        {
            _context = context;
            _nearbySearchService = nearbySearchService;
        }

        public async ValueTask<GetItemsList<CandidateResponseModel>> Handle(GetCandidatesNearbyRecruiterRequest request, CancellationToken cancellationToken)
        {
            var recruiter = await _context.Recruiters.AsNoTracking().FirstOrDefaultAsync(e => e.UserGID == request.UserGID);
            var result = new GetItemsList<CandidateResponseModel>();

            if (recruiter is null)
                throw new Exception($"Recruiter with Guid {request.UserGID} not found");

            var recruiterLocation = await _nearbySearchService.GetLocationByAddress(recruiter.Location, cancellationToken);

            //var candidates = await _context.Candidates.AsNoTracking().ToListAsync(cancellationToken);

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

            foreach (var candidate in candidates)
            {
                var isMatch = await _nearbySearchService.CheckCityInRadius(new LocationRequestModel
                {
                    MainLocation = recruiterLocation,
                    ReferenceAddress = candidate.Location,
                    MaxDistance = request.MaxDistance
                }, cancellationToken);

                if (isMatch)
                {
                    result.Items.Add(candidate);
                }
            }

            return result;
        }
    }
}
