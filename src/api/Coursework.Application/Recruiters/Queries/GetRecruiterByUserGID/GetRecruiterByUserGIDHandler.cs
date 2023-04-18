using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Recruiters.Queries.GetRecruiterByUserGID
{
    public class GetRecruiterByUserGIDHandler : IRequestHandler<GetRecruiterByUserGIDRequest, Recruiter>
    {
        private readonly CoursworkContext _context;

        public GetRecruiterByUserGIDHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Recruiter> Handle(GetRecruiterByUserGIDRequest request, CancellationToken cancellationToken)
        {
            var recruiter = await _context.Recruiters.AsNoTracking().Join(
                _context.Users, 
                recruiter => recruiter.UserGID,
                user => user.GID,
                (recruiter, user) => new Recruiter
                {
                    GID = recruiter.GID,
                    FirstName = recruiter.FirstName,
                    LastName = recruiter.LastName,
                    CompanyName = recruiter.CompanyName,
                    PhoneNumber = recruiter.PhoneNumber,
                    Biography = recruiter.Biography,
                    Location = recruiter.Location,
                    UserGID = user.GID,
                }).FirstOrDefaultAsync(e => e.UserGID == request.UserGID);

            return recruiter;
        }
    }
}
