using Coursework.Application.Candidates.Commands.CreateCandidate;
using Coursework.Application.Candidates.Commands.DeleteCandidate;
using Coursework.Application.Candidates.Commands.UpdateCandidate;
using Coursework.Application.Candidates.Queries.GetCandidateByUserGID;
using Coursework.Application.Candidates.Queries.GetCandidatesByBio;
using Coursework.Application.Candidates.Queries.GetCandidatesByResume;
using Coursework.Application.Candidates.Queries.GetCandidatesBySkills;
using Coursework.Persistence;
using Mediator;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllCandidates(CancellationToken cancellationToken)
        {
            var candidates = (
                from candidate in _context.Candidates
                join user in _context.Users on candidate.UserGID equals user.GID
                join candidateSkill in _context.CandidateSkills on candidate.GID equals candidateSkill.CandidateGID
                join skill in _context.Skills on candidateSkill.SkillGID equals skill.GID
                group skill by candidate into g
                select new
                {
                    GID = g.Key.GID,
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    PhoneNumber = g.Key.PhoneNumber,
                    Biography = g.Key.Biography,
                    Resume = g.Key.Resume,
                    Location = g.Key.Location,
                    UserGID = g.Key.UserGID,
                    UserEmail = g.Key.User.Email,
                    UserRole = g.Key.User.Role,
                    Skills = g.ToList()
                }
            ).ToList();


            return Ok(candidates);
        }

        [HttpGet("candidatebyusergid")]
        public async Task<IActionResult> GetCandidateByUserGID(string userGID)
        {
            var result = await _mediator.Send(new GetCandidateByUserGIDRequest { UserGID = Guid.Parse(userGID) });

            return Ok(result);
        }

        [HttpPost("candidatesbyskills")]
        public async Task<IActionResult> GetCandidatesBySkills([FromBody] List<string> skills)
        {
            var result = await _mediator.Send(new GetCandidatesBySkillsRequest { Skills = skills });

            return Ok(result);
        }

        [HttpPost("candidatesbyresume")]
        public async Task<IActionResult> GetCandidatesByResume([FromBody] List<string> resume)
        {
            var result = await _mediator.Send(new GetCandidatesByResumeRequest { Resume = resume });

            return Ok(result);
        }

        [HttpPost("candidatesbybio")]
        public async Task<IActionResult> GetCandidatesByBio([FromBody] List<string> bio)
        {
            var result = await _mediator.Send(new GetCandidatesByBioRequest { Bio = bio });

            return Ok(result);
        }
    }
}
