using Coursework.Application.Recruiters.Commands.CreateRecruiter;
using Coursework.Application.Recruiters.Commands.DeleteRecruiter;
using Coursework.Application.Recruiters.Commands.UpdateRecruiter;
using Coursework.Application.Recruiters.Queries.GetCandidatesNearbyRecruiter;
using Coursework.Application.Recruiters.Queries.GetRecruiterByUserGID;
using Coursework.Persistence;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Сoursework.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CoursworkContext _context;

        public RecruiterController(IMediator mediator, CoursworkContext context)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRecruiter([FromBody] CreateRecruiterRequest createRecruiterRequest)
        {
            var result = await _mediator.Send(createRecruiterRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteRecruiter([FromBody] DeleteRecruiterRequest deleteRecruiterRequest)
        {
            var result = await _mediator.Send(deleteRecruiterRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRecruiter([FromBody] UpdateRecruiterRequest updateRecruiterRequest)
        {
            var result = await _mediator.Send(updateRecruiterRequest);
            return Ok(result);
        }

        [HttpGet("recruiters")]
        public async Task<IActionResult> GetAllRecruiters()
        {
            var recruiters = await _context.Recruiters.Join(_context.Users,
                recruiter => recruiter.UserGID,
                user => user.GID,
                (recruiter, user) => new
                {
                    recruiter.GID,
                    recruiter.FirstName,
                    recruiter.LastName,
                    recruiter.CompanyName,
                    recruiter.PhoneNumber,
                    recruiter.Biography,
                    recruiter.Location,
                    recruiter.UserGID,
                    user.Email,
                    user.Role
                }).ToListAsync();

            return Ok(recruiters);
        }

        [HttpGet("recruiterbyusergid")]
        public async Task<IActionResult> GetRecruiterByUserGID(string userGID)
        {
            var result = await _mediator.Send(new GetRecruiterByUserGIDRequest { UserGID = Guid.Parse(userGID) });

            return Ok(result);
        }

        [HttpGet("candidatesnearby")]
        public async Task<IActionResult> GetCandidateNearByRecruiter(string userGID, int maxDistance)
        {
            var result = await _mediator.Send(new GetCandidatesNearbyRecruiterRequest { UserGID = Guid.Parse(userGID), MaxDistance = maxDistance });

            return Ok(result);
        }
    }
}
