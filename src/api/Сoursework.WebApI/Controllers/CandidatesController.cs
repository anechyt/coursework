using Coursework.Application.Candidates.Commands.CreateCandidate;
using Coursework.Application.Candidates.Commands.DeleteCandidate;
using Coursework.Application.Candidates.Commands.UpdateCandidate;
using Coursework.Application.Candidates.Queries.GetCandidateByUserGID;
using Coursework.Persistence;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Сoursework.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CoursworkContext _context;

        public CandidatesController(IMediator mediator, CoursworkContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCandidate([FromBody] CreateCandidateRequest createCandidateRequest)
        {
            var result = await _mediator.Send(createCandidateRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCandidate([FromBody] DeleteCandidateRequest deleteCandidateRequest)
        {
            var result = await _mediator.Send(deleteCandidateRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCandidate([FromBody] UpdateCandidateRequest updateCandidateRequest)
        {
            var result = await _mediator.Send(updateCandidateRequest);
            return Ok(result);
        }

        [HttpGet("candidates")]
        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _context.Candidates.Join(_context.Users,
                candidate => candidate.UserGID,
                user => user.GID,
                (candidate, user) => new
                {
                    candidate.GID,
                    candidate.FirstName,
                    candidate.LastName,
                    candidate.PhoneNumber,
                    candidate.Biography,
                    candidate.Resume,
                    candidate.UserGID,
                    user.Email,
                    user.Role
                }).ToListAsync();

            return Ok(candidates);
        }

        [HttpGet("candidatebyusergid")]
        public async Task<IActionResult> GetCandidateByUserGID(string userGID)
        {
            var result = await _mediator.Send(new GetCandidateByUserGIDRequest { UserGID = Guid.Parse(userGID) });

            return Ok(result);
        }
    }
}
