using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.NearbySearch.Abstract;
using Coursework.Application.NearbySearch.Models;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Recruiters.Queries.GetCandidatesNearbyRecruiter
{
    public class GetCandidatesNearbyRecruiterHandler : IRequestHandler<GetCandidatesNearbyRecruiterRequest, GetItemsList<Candidate>>
    {
        private readonly CoursworkContext _context;
        private readonly INearbySearchService _nearbySearchService;

        public GetCandidatesNearbyRecruiterHandler(CoursworkContext context, INearbySearchService nearbySearchService)
        {
            _context = context;
            _nearbySearchService = nearbySearchService;
        }

        public async ValueTask<GetItemsList<Candidate>> Handle(GetCandidatesNearbyRecruiterRequest request, CancellationToken cancellationToken)
        {
            var recruiter = await _context.Recruiters.AsNoTracking().FirstOrDefaultAsync(e => e.UserGID == request.UserGID);
            var result = new GetItemsList<Candidate>();

            if (recruiter is null)
                throw new Exception($"Recruiter with Guid {request.UserGID} not found");

            var recruiterLocation = await _nearbySearchService.GetLocationByAddress(recruiter.Location, cancellationToken);

            var candidates = await _context.Candidates.AsNoTracking().ToListAsync(cancellationToken);

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
