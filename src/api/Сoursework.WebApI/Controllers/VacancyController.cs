using Coursework.Application.Candidates.Queries.GetCandidatesBySkills;
using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.Vacancies.Commands.CreateVacancy;
using Coursework.Application.Vacancies.Commands.DeleteVacancy;
using Coursework.Application.Vacancies.Models;
using Coursework.Application.Vacancies.Queries.GetVacanciesByRecruiterGID;
using Coursework.Application.Vacancies.Queries.GetVacanciesBySkills;
using Coursework.Application.Vacancies.Queries.GetVacanciesNearbyCandidate;
using Coursework.Persistence;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Сoursework.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CoursworkContext _context;

        public VacancyController(IMediator mediator, CoursworkContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVacancy([FromBody] CreateVacancyRequest createVacancyRequest)
        {
            var result = await _mediator.Send(createVacancyRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteVacancy([FromBody] DeleteVacancyRequest deleteVacancyRequest)
        {
            var result = await _mediator.Send(deleteVacancyRequest);
            return Ok(result);
        }

        [HttpGet("vacancies")]
        public async Task<IActionResult> GetAllVacancies(CancellationToken cancellationToken)
        {
            var vacancies = await (
                    from vacancy in _context.Vacancies
                    join vacancyStatus in _context.VacancyStatuses on vacancy.VacancyStatusGID equals vacancyStatus.GID
                    join recruiter in _context.Recruiters on vacancy.RecruiterGID equals recruiter.GID
                    join vacancySkills in _context.VacancySkills on vacancy.GID equals vacancySkills.VacancyGID
                    join skill in _context.Skills on vacancySkills.SkillGID equals skill.GID
                    group skill by vacancy into g
                    select new VacancyResponseModel
                    {
                        GID = g.Key.GID,
                        Name = g.Key.Name,
                        Description = g.Key.Description,
                        Salary = g.Key.Salary,
                        Location = g.Key.Location,
                        VacancyStatusName = g.Key.VacancyStatus.Name,
                        RecruiterFirstName = g.Key.Recruiter.FirstName,
                        RecruiterLastName = g.Key.Recruiter.LastName,
                        RecruiterPhoneNumber = g.Key.Recruiter.PhoneNumber,
                        Skills = g.ToList()
                    }
                ).ToListAsync(cancellationToken);

            return Ok(new GetItemsList<VacancyResponseModel> { Items = vacancies });
        }

        [HttpGet("vacanciesbyrecruitergid")]
        public async Task<IActionResult> GetVacanciesByRecruiterGID(string recruiterGID)
        {
            var result = await _mediator.Send(new GetVacanciesByRecruiterGIDRequest { RecruiterGID = Guid.Parse(recruiterGID) });

            return Ok(result);
        }

        [HttpGet("vacanciesnearby")]
        public async Task<IActionResult> GetVacanciesNearByCandidate(string userGID, int maxDistance)
        {
            var result = await _mediator.Send(new GetVacanciesNearbyCandidateRequest { UserGID = Guid.Parse(userGID), MaxDistance = maxDistance });

            return Ok(result);
        }

        [HttpPost("vacanciesbyskills")]
        public async Task<IActionResult> GetVacanciesBySkills([FromBody] List<string> skills)
        {
            var result = await _mediator.Send(new GetVacanciesBySkillsRequest { Skills = skills });

            return Ok(result);
        }
    }
}
