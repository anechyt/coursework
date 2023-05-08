using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Candidates.Queries.GetCandidateByUserGID
{
    public class GetCandidateByUserGIDHandler : IRequestHandler<GetCandidateByUserGIDRequest, Candidate>
    {
        private readonly CoursworkContext _context;

        public GetCandidateByUserGIDHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Candidate> Handle(GetCandidateByUserGIDRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.AsNoTracking().Join(
                _context.Users,
                candidate => candidate.UserGID,
                user => user.GID,
                (candidate, user) => new Candidate
                {
                    GID = candidate.GID,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    PhoneNumber = candidate.PhoneNumber,
                    Biography = candidate.Biography,
                    Location = candidate.Location,
                    Resume = candidate.Resume,
                    UserGID = user.GID,
                }).FirstOrDefaultAsync(e => e.UserGID == request.UserGID);

            return candidate;
        }
    }
}
