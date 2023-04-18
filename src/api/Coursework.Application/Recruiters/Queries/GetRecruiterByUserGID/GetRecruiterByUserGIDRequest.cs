using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Recruiters.Queries.GetRecruiterByUserGID
{
    public class GetRecruiterByUserGIDRequest : IRequest<Recruiter>
    {
        public Guid UserGID { get; set; }
    }
}
